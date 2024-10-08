﻿using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;
using Savonia.Assignment.Tool.Models;
using VSTest;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsTestRunCommand : Command
{
    // savoniatool submissions test run <sourcePath> <testsJsonFile> --selected-submissions 1-10 --test-log-file log.trx --test-data-prefix real

    public SubmissionsTestRunCommand() : base("run", "Run tests for each selected submissions.")
    {
        var testsJsonArgument = new Argument<FileInfo>(
            name: "testsJsonFile",
            description: "JSON file containing test definitions. Use GitHub Classroom autograding json file definition."
            );

        testsJsonArgument.AddValidator(result =>
        {
            var file = result.GetValueForArgument(testsJsonArgument).FullName ?? string.Empty;
            if (false == File.Exists(file))
            {
                result.ErrorMessage = $"Tests JSON file '{file}' does not exist";
            }
            else
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var tests = JsonSerializer.Deserialize<GitHubClassroomTests>(json);
                    if (tests == null)
                    {
                        result.ErrorMessage = $"Tests JSON file '{file}' is not valid GitHub Classroom autograding json file";
                    }
                }
                catch (Exception ex)
                {
                    result.ErrorMessage = $"Tests JSON file '{file}' is not valid GitHub Classroom autograding json file";
                }
            }
        });

        var testDataPrefixOption = new Option<string>(
            name: "--test-data-prefix",
            description: "Prefix to add to test data file names before reading the test data. Is used to run tests with different test data.",
            getDefaultValue: () => "");

        var testLogFileOption = new Option<string>(
            name: "--test-log-file",
            description: "Test log file name used to write and read test results. The file is relative to TestResults folder in each test directory.",
            getDefaultValue: () => "savoniatool.trx");

        var testSummaryFileOption = new Option<string>(
            name: "--test-summary-file",
            description: "Test summary file name used to write test results JSON to each submission folder root. By default will overwrite possible existing file.",
            getDefaultValue: () => "testrunsummary.json");

        var overwriteSummaryFileOption = new Option<bool>(
            name: "--overwrite-summary-file",
            description: "Overwrite possible existing test summary file. Defaults to true. If set to false, will preserve existing file and append new results to it. This may cause duplicate test results and points in the file.",
            getDefaultValue: () => true);

        var selectedSubmissionsOption = new Option<List<string>?>(
            name: "--selected-submissions",
            description: "Set index number of submission folders to run tests on. Use 'submissions list' command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            getDefaultValue: () => new List<string> { })
        {
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourcePathArgument);
        Add(testsJsonArgument);
        Add(testDataPrefixOption);
        Add(testLogFileOption);
        Add(testSummaryFileOption);
        Add(overwriteSummaryFileOption);
        Add(selectedSubmissionsOption);

        this.SetHandler(async (source, testsJsonFile, testDataPrefix, logFile, summaryFile, overwriteSummaryFile, selectedSubmissions, verbose) =>
        {
            await Handle(source, testsJsonFile, testDataPrefix, logFile, summaryFile, overwriteSummaryFile, selectedSubmissions, verbose);
        },
        CommonArguments.SourcePathArgument, testsJsonArgument, testDataPrefixOption, testLogFileOption, testSummaryFileOption, overwriteSummaryFileOption, selectedSubmissionsOption, GlobalOptions.VerboseOption);

    }

    async Task Handle(DirectoryInfo path,
                        FileInfo testsJsonFile,
                        string? testDataPrefix,
                        string logFile,
                        string summaryFile,
                        bool overwriteSummaryFile,
                        List<string>? selectedSubmissions,
                        bool verbose)
    {
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);

        var tests = JsonSerializer.Deserialize<GitHubClassroomTests>(testsJsonFile.OpenRead());

        // run tests
        Directory.SetCurrentDirectory(path.FullName);
        await RunTests(tests!, testDataPrefix, verbose, answerDirectories, logFile, summaryFile, overwriteSummaryFile);
    }

    private async Task RunTests(GitHubClassroomTests tests, string? testDataPrefix, bool verbose, DirectoryInfo[] submissions, string logFile, string summaryFile, bool overwriteSummaryFile)
    {
        // run tests on each answer directory
        bool testDataPrefixHasValue = false == string.IsNullOrEmpty(testDataPrefix);

        Console.WriteLine($"\nRunning {tests.Tests.Count} test(s) in {submissions.Length} submission(s).");
        if (testDataPrefixHasValue)
        {
            Console.WriteLine($"- Setting environment variable TEST_DATA_PREFIX={testDataPrefix!}");
        }

        int counter = 1;
        int submissionsCount = submissions.Length;
        foreach (var answerDir in submissions)
        {
            if (verbose)
            {
                Console.WriteLine();
                Console.WriteLine($"----");
                Console.WriteLine($"{counter,4} {answerDir.Name}");
            }
            FileInfo summaryFileInfo = new FileInfo(Path.Combine(answerDir.FullName, summaryFile));

            TestRunSummary? summary = null;

            if (false == overwriteSummaryFile)
            {
                if (summaryFileInfo.Exists)
                {
                    // read existing summary file
                    using (var stream = summaryFileInfo.OpenRead())
                    {
                        summary = await System.Text.Json.JsonSerializer.DeserializeAsync<TestRunSummary>(stream);
                    }
                }
            }
            summary ??= new TestRunSummary()
            {
                MaximumPoints = tests.Tests.Sum(t => t.Points) + (tests.Preparation?.Points ?? 0) + (tests.Cleanup?.Points ?? 0),
                Assignment = answerDir.Parent?.Name,
                Submission = answerDir.Name,
                TestRunTime = DateTime.Now,
                Points = 0
            };
            if (tests.Preparation is not null)
            {
                if (verbose)
                {
                    Console.WriteLine($"    - running test preparation with command: '{tests.Preparation}'");
                }
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(tests.Preparation.CommandName, tests.Preparation.Arguments ?? string.Empty);
                    psi.WorkingDirectory = answerDir.FullName;
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = false;
                    var p = Process.Start(psi);
                    if (null != p)
                    {
                        await p.WaitForExitAsync();
                        summary.PreparationExitCode = p.ExitCode;
                        if (tests.Preparation.SuccessExitCode == p.ExitCode)
                        {
                            summary.Points += tests.Preparation.Points ?? 0;
                        }
                        else
                        {
                            Console.WriteLine($"\t-preparation command '{tests.Preparation}' on {answerDir.Name} exited with non-success code {p.ExitCode}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"*****\nError executing the test preparation command '{tests.Preparation}' on {answerDir.Name}:\n{e.Message}\n*****");
                }
            }
            foreach (var test in tests.Tests)
            {
                if (verbose)
                {
                    Console.WriteLine($"    - running test: '{test.Name}' with command: '{test.Run}'");
                }
                var testCommands = test.Run.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var summaryItem = new TestRunSummaryItem()
                {
                    RunCommand = test.Run,
                    TestName = test.Name,
                    Path = testCommands.Skip(2).FirstOrDefault()
                };
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(testCommands[0], $"{string.Join(' ', testCommands.Skip(1))} --blame-hang-timeout {test.Timeout.SecondsToMs()} --logger \"trx;logfilename={logFile}\"");
                    psi.WorkingDirectory = answerDir.FullName;
                    if (testDataPrefixHasValue)
                    {
                        psi.EnvironmentVariables.Add("TEST_DATA_PREFIX", testDataPrefix!);
                    }
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = false;
                    var p = Process.Start(psi);
                    if (null != p)
                    {
                        await p.WaitForExitAsync();
                        summaryItem.RunnerExitCode = p.ExitCode;
                        summaryItem.Points = p.ExitCode == 0 ? test.Points : 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"*****\nError executing the test runner on {answerDir.Name} for test '{test.Name}':\n{e.Message}\n*****");
                }

                // read test results from log file
                ReadTestResultsFromLogFile(answerDir, logFile, summaryItem, testCommands.Skip(2).FirstOrDefault(), verbose);

                summary.SummaryItems.Add(summaryItem);
            }
            summary.Points += summary.SummaryItems.Sum(i => i.Points);

            if (tests.Cleanup is not null)
            {
                if (verbose)
                {
                    Console.WriteLine($"    - running test cleanup with command: '{tests.Cleanup}'");
                }
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(tests.Cleanup.CommandName, tests.Cleanup.Arguments ?? string.Empty);
                    psi.WorkingDirectory = answerDir.FullName;
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = false;
                    var p = Process.Start(psi);
                    if (null != p)
                    {
                        await p.WaitForExitAsync();
                        summary.CleanupExitCode = p.ExitCode;
                        if (tests.Cleanup.SuccessExitCode == p.ExitCode)
                        {
                            summary.Points += tests.Cleanup.Points ?? 0;
                        }
                        else
                        {
                            Console.WriteLine($"\t-cleanup command '{tests.Cleanup}' on {answerDir.Name} exited with non-success code {p.ExitCode}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"*****\nError executing the test cleanup command '{tests.Cleanup}' on {answerDir.Name}:\n{e.Message}\n*****");
                }
            }

            // write summary to file
            if (summaryFileInfo.Exists)
            {
                summaryFileInfo.Delete();
            }
            using (var stream = summaryFileInfo.OpenWrite())
            {
                await System.Text.Json.JsonSerializer.SerializeAsync(stream, summary, new JsonSerializerOptions() { WriteIndented = true, PropertyNameCaseInsensitive = true });
            }

            if (verbose)
            {
                Console.WriteLine();
                Console.WriteLine($"{counter} of {submissionsCount} submissions tested.");
            }
            counter++;
        }
    }

    private void ReadTestResultsFromLogFile(DirectoryInfo submission, string logFile, TestRunSummaryItem summaryItem, string testPath, bool verbose)
    {
        var path = Path.Combine(submission.FullName, testPath, "TestResults", logFile);
        FileInfo source = new FileInfo(path);
        if (false == source.Exists)
        {
            if (verbose)
            {
                Console.WriteLine($"*****\nTest results file '{path}' not found.\n*****");
            }
            summaryItem.Outcome = "Required code under test was not found. Test failed.";
            summaryItem.Points = 0;
            return;
        }
        try
        {
            TestRunType testRun = source.ReadTestRunResults();
            // var definitions = testRun.TestDefinitions.FirstOrDefault();
            // var unitTest = definitions.UnitTest.FirstOrDefault();
            var summary = testRun.ResultSummary.FirstOrDefault();
            var counters = summary.Counters.FirstOrDefault();
            var results = testRun.Results.FirstOrDefault();
            var testResults = results.UnitTestResult;

            summaryItem.Outcome = summary.Outcome;
            summaryItem.Counters = $"Tests: total {counters.Total}, passed {counters.Passed}, failed {counters.Failed}";
            foreach (var tr in testResults.Where(t => t.Outcome.Equals("failed", StringComparison.OrdinalIgnoreCase)))
            {
                var output = tr.Output.FirstOrDefault();
                var errorInfo = output.ErrorInfo;
                var message = errorInfo.Message as XmlNode[];
                var stackTrace = errorInfo.StackTrace as XmlNode[];
                summaryItem.Outputs.Add(new TestRunOutput
                {
                    Info = $"{tr.TestName} - {tr.Outcome}",
                    Message = message.FirstOrDefault()?.InnerText,
                    StackTrace = stackTrace.FirstOrDefault()?.InnerText,
                });
            }
        }
        catch (Exception ex)
        {
            var cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!FAILED to convert file {source.Name}.\n\n{ex.Message}");
            Console.ForegroundColor = cc;
        }

    }
}
