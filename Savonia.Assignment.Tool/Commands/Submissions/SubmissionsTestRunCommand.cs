using System.CommandLine;
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
        var testsJsonArgument = new Argument<FileInfo>("testsJsonFile")
        {
            Description = "JSON file containing test definitions. Use GitHub Classroom autograding json file definition."
        };

        testsJsonArgument.Validators.Add(result =>
        {
            var file = result.GetValue(testsJsonArgument).FullName ?? string.Empty;
            if (false == File.Exists(file))
            {
                result.AddError($"Tests JSON file '{file}' does not exist");
            }
            else
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var tests = JsonSerializer.Deserialize<GitHubClassroomTests>(json);
                    if (tests == null)
                    {
                        result.AddError($"Tests JSON file '{file}' is not valid GitHub Classroom autograding json file");
                    }
                }
                catch (Exception ex)
                {
                    result.AddError($"Tests JSON file '{file}' is not valid GitHub Classroom autograding json file");
                }
            }
        });

        var testDataPrefixOption = new Option<string>("--test-data-prefix")
        {
            Description = "Prefix to add to test data file names before reading the test data. Is used to run tests with different test data.",
            DefaultValueFactory = _ => ""
        };

        var testLogFileOption = new Option<string>("--test-log-file")
        {
            Description = "Test log file name used to write and read test results. The file is relative to TestResults folder in each test directory.",
            DefaultValueFactory = _ => "savoniatool.trx"
        };

        var testSummaryFileOption = new Option<string>("--test-summary-file")
        {
            Description = "Test summary file name used to write test results JSON to each submission folder root. By default will overwrite possible existing file.",
            DefaultValueFactory = _ => "testrunsummary.json"
        };

        var overwriteSummaryFileOption = new Option<bool>("--overwrite-summary-file")
        {
            Description = "Overwrite possible existing test summary file. Defaults to true. If set to false, will preserve existing file and append new results to it. This may cause duplicate test results and points in the file.",
            DefaultValueFactory = _ => true
        };

        var saveConsoleLogOption = new Option<bool>("--save-console-log")
        {
            Description = "Save console output to a text file in the source folder. The file is named after the source folder with a timestamp (yyyy-MM-dd-HH-mm). Defaults to true.",
            DefaultValueFactory = _ => true
        };

        var maxParallelOption = new Option<int>("--max-parallel")
        {
            Description = "Maximum number of submissions to test in parallel. Defaults to 0 which runs submissions sequentially. Recommended values: 3-5 for typical machines. Higher values may cause resource contention and instability in test runs, especially if the tests are resource intensive.",
            DefaultValueFactory = _ => 0
        };

        var selectedSubmissionsOption = new Option<List<string>?>("--selected-submissions")
        {
            Description = "Set index number of submission folders to run tests on. Use 'submissions list' command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            DefaultValueFactory = _ => [],
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourcePathArgument);
        Add(testsJsonArgument);
        Add(testDataPrefixOption);
        Add(testLogFileOption);
        Add(testSummaryFileOption);
        Add(overwriteSummaryFileOption);
        Add(saveConsoleLogOption);
        Add(maxParallelOption);
        Add(selectedSubmissionsOption);

        this.SetAction(async (parseResult) =>
        {
            await Handle(
                parseResult.GetValue(CommonArguments.SourcePathArgument)!,
                parseResult.GetValue(testsJsonArgument)!,
                parseResult.GetValue(testDataPrefixOption),
                parseResult.GetValue(testLogFileOption),
                parseResult.GetValue(testSummaryFileOption),
                parseResult.GetValue(overwriteSummaryFileOption),
                parseResult.GetValue(saveConsoleLogOption),
                parseResult.GetValue(maxParallelOption),
                parseResult.GetValue(selectedSubmissionsOption),
                parseResult.GetValue(GlobalOptions.VerboseOption)
            );
        });
    }

    async Task Handle(DirectoryInfo path,
                        FileInfo testsJsonFile,
                        string? testDataPrefix,
                        string logFile,
                        string summaryFile,
                        bool overwriteSummaryFile,
                        bool saveConsoleLog,
                        int maxParallel,
                        List<string>? selectedSubmissions,
                        bool verbose)
    {
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);

        var tests = JsonSerializer.Deserialize<GitHubClassroomTests>(testsJsonFile.OpenRead());

        // run tests
        Directory.SetCurrentDirectory(path.FullName);
        await RunTests(tests!, testDataPrefix, verbose, answerDirectories, logFile, summaryFile, overwriteSummaryFile, saveConsoleLog, maxParallel);
    }

    private async Task RunTests(GitHubClassroomTests tests, string? testDataPrefix, bool verbose, DirectoryInfo[] submissions, string logFile, string summaryFile, bool overwriteSummaryFile, bool saveConsoleLog, int maxParallel)
    {
        string cwd = Directory.GetCurrentDirectory();
        string cwdName = new DirectoryInfo(cwd).Name;
        string consoleLogPath = Path.Combine(cwd, $"{cwdName}-{DateTime.Now:yyyy-MM-dd-HH-mm}.txt");

        StreamWriter? fileWriter = null;
        TextWriter originalOut = Console.Out;
        if (saveConsoleLog)
        {
            fileWriter = new StreamWriter(consoleLogPath, append: false, encoding: new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            Console.SetOut(new TeeTextWriter(originalOut, fileWriter));
        }
        try
        {
            await RunTestsCore(tests, testDataPrefix, verbose, submissions, logFile, summaryFile, overwriteSummaryFile, maxParallel);
        }
        finally
        {
            Console.SetOut(originalOut);
            if (fileWriter is not null)
            {
                await fileWriter.FlushAsync();
                await fileWriter.DisposeAsync();
                Console.WriteLine($"Console log saved to: {consoleLogPath}");
            }
        }
    }

    private async Task RunTestsCore(GitHubClassroomTests tests, string? testDataPrefix, bool verbose, DirectoryInfo[] submissions, string logFile, string summaryFile, bool overwriteSummaryFile, int maxParallel)
    {
        // run tests on each answer directory
        bool testDataPrefixHasValue = false == string.IsNullOrEmpty(testDataPrefix);
        var runErrors = new List<(string Submission, string Test, string Message)>();

        Console.WriteLine($"\nRunning {tests.Tests.Count} test(s) in {submissions.Length} submission(s){(maxParallel > 0 ? $" with up to {maxParallel} in parallel" : "")}.");
        if (testDataPrefixHasValue)
        {
            Console.WriteLine($"- Setting environment variable TEST_DATA_PREFIX={testDataPrefix!}");
        }

        int submissionsCount = submissions.Length;

        if (maxParallel <= 0)
        {
            // sequential
            int counter = 1;
            foreach (var answerDir in submissions)
            {
                var errors = await ProcessSubmissionAsync(answerDir, counter, submissionsCount, tests, testDataPrefix, testDataPrefixHasValue, verbose, logFile, summaryFile, overwriteSummaryFile, Console.Out, useColors: true);
                runErrors.AddRange(errors);
                counter++;
            }
        }
        else
        {
            // parallel — each submission buffers its output, then flushes atomically to the console
            var consoleLock = new SemaphoreSlim(1, 1);
            var errorBag = new System.Collections.Concurrent.ConcurrentBag<(string, string, string)>();
            await Parallel.ForEachAsync(
                submissions.Select((dir, idx) => (dir, idx: idx + 1)),
                new ParallelOptions { MaxDegreeOfParallelism = maxParallel },
                async (item, _) =>
                {
                    var sw = new StringWriter();
                    var errors = await ProcessSubmissionAsync(item.dir, item.idx, submissionsCount, tests, testDataPrefix, testDataPrefixHasValue, verbose, logFile, summaryFile, overwriteSummaryFile, sw, useColors: false);
                    foreach (var e in errors) errorBag.Add(e);
                    await consoleLock.WaitAsync();
                    try { Console.Write(sw.ToString()); }
                    finally { consoleLock.Release(); }
                });
            runErrors.AddRange(errorBag);
        }

        if (runErrors.Count > 0)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{'=',60}");
            Console.WriteLine($"  {runErrors.Count} test runner error(s) occurred during the run:");
            Console.WriteLine($"{'=',60}");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var (submission, test, message) in runErrors)
            {
                Console.WriteLine($"  [{submission}] '{test}': {message}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{'=',60}");
            Console.ForegroundColor = prevColor;
        }
    }

    private async Task<List<(string Submission, string Test, string Message)>> ProcessSubmissionAsync(
        DirectoryInfo answerDir,
        int counter,
        int submissionsCount,
        GitHubClassroomTests tests,
        string? testDataPrefix,
        bool testDataPrefixHasValue,
        bool verbose,
        string logFile,
        string summaryFile,
        bool overwriteSummaryFile,
        TextWriter output,
        bool useColors)
    {
        var localErrors = new List<(string Submission, string Test, string Message)>();

        output.WriteLine();
        output.WriteLine($"[{counter}/{submissionsCount}] {answerDir.Name}");

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
                output.WriteLine($"    - running test preparation with command: '{tests.Preparation}'");
            }
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(tests.Preparation.CommandName, tests.Preparation.Arguments ?? string.Empty);
                psi.WorkingDirectory = answerDir.FullName;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                var p = Process.Start(psi);
                if (null != p)
                {
                    _ = p.StandardOutput.ReadToEndAsync();
                    _ = p.StandardError.ReadToEndAsync();
                    await p.WaitForExitAsync();
                    summary.PreparationExitCode = p.ExitCode;
                    if (tests.Preparation.SuccessExitCode == p.ExitCode)
                    {
                        summary.Points += tests.Preparation.Points ?? 0;
                    }
                    else
                    {
                        output.WriteLine($"\t-preparation command '{tests.Preparation}' on {answerDir.Name} exited with non-success code {p.ExitCode}");
                    }
                }
            }
            catch (Exception e)
            {
                output.WriteLine($"*****\nError executing the test preparation command '{tests.Preparation}' on {answerDir.Name}:\n{e.Message}\n*****");
            }
        }
        int testIdx = 0;
        int testCount = tests.Tests.Count;
        foreach (var test in tests.Tests)
        {
            testIdx++;
            output.Write($"  [{testIdx}/{testCount}] {test.Name,-45}");
            if (verbose)
            {
                output.WriteLine();
                output.Write($"        command: '{test.Run}' ... ");
            }
            var testCommands = test.Run.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var summaryItem = new TestRunSummaryItem()
            {
                RunCommand = test.Run,
                TestName = test.Name,
                Path = testCommands.Skip(2).FirstOrDefault()
            };
            string processOutput = string.Empty;
            string processError = string.Empty;
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(testCommands[0], $"{string.Join(' ', testCommands.Skip(1))} --blame-hang-timeout {test.Timeout.SecondsToMs()} --logger \"trx;logfilename={logFile}\"");
                psi.WorkingDirectory = answerDir.FullName;
                if (testDataPrefixHasValue)
                {
                    psi.EnvironmentVariables.Add("TEST_DATA_PREFIX", testDataPrefix!);
                }
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                var p = Process.Start(psi);
                if (null != p)
                {
                    var stdoutTask = p.StandardOutput.ReadToEndAsync();
                    var stderrTask = p.StandardError.ReadToEndAsync();
                    await p.WaitForExitAsync();
                    processOutput = await stdoutTask;
                    processError = await stderrTask;
                    summaryItem.RunnerExitCode = p.ExitCode;
                    summaryItem.Points = p.ExitCode == 0 ? test.Points : 0;
                    if (p.ExitCode == 2)
                    {
                        // dotnet test exit code 2 = test run aborted (e.g. --blame-hang-timeout fired)
                        summaryItem.Outcome = "Test run aborted";
                        var abortMsg = $"Test runner aborted - exceeded hang timeout of {test.Timeout} seconds. Test results may be incomplete.";
                        summaryItem.Outputs.Add(new TestRunOutput
                        {
                            Info = $"Test runner aborted (exit code 2)",
                            Message = abortMsg,
                            StackTrace = string.Empty
                        });
                        localErrors.Add((answerDir.Name, test.Name, abortMsg));
                    }
                    else if (p.ExitCode < 0)
                    {
                        // negative exit code = abnormal process termination (OS signal / killed)
                        summaryItem.Outcome = $"Test runner terminated abnormally (exit code {p.ExitCode})";
                        var killMsg = $"The test runner process was terminated abnormally with exit code {p.ExitCode}. This may indicate the process was killed by the OS (e.g. out-of-memory) or an unhandled crash.";
                        summaryItem.Outputs.Add(new TestRunOutput
                        {
                            Info = $"Abnormal process termination (exit code {p.ExitCode})",
                            Message = killMsg,
                            StackTrace = string.Empty
                        });
                        localErrors.Add((answerDir.Name, test.Name, killMsg));
                    }
                }
                else
                {
                    summaryItem.Outcome = "Test runner did not start";
                    var noStartMsg = $"The test runner process could not be started for command '{test.Run}'.";
                    summaryItem.Outputs.Add(new TestRunOutput
                    {
                        Info = "Process start returned null",
                        Message = noStartMsg,
                        StackTrace = string.Empty
                    });
                    localErrors.Add((answerDir.Name, test.Name, noStartMsg));
                }
            }
            catch (Exception e)
            {
                summaryItem.Outcome = "Test runner error";
                summaryItem.Outputs.Add(new TestRunOutput
                {
                    Info = $"Exception starting test runner",
                    Message = e.Message,
                    StackTrace = e.StackTrace ?? string.Empty
                });
                localErrors.Add((answerDir.Name, test.Name, $"Exception: {e.Message}"));
                output.WriteLine($"*****\nError executing the test runner on {answerDir.Name} for test '{test.Name}':\n{e.Message}\n*****");
            }

            // read test results from log file
            ReadTestResultsFromLogFile(answerDir, logFile, summaryItem, testCommands.Skip(2).FirstOrDefault(), verbose, output);

            if (summaryItem.Outcome is null)
            {
                // exit codes 0 and 1 are normal dotnet test outcomes (passed / some tests failed)
                summaryItem.Outcome = summaryItem.RunnerExitCode <= 1 ? (summaryItem.RunnerExitCode == 0 ? "Completed" : "Failed") : $"Test run did not complete (exit code {summaryItem.RunnerExitCode})";
            }

            // print colored outcome completing the progress line
            var outcomeColor = summaryItem.Outcome switch
            {
                "Passed" or "Completed"  => ConsoleColor.Green,
                "Failed"                 => ConsoleColor.DarkYellow,
                _                        => ConsoleColor.Red
            };
            if (useColors)
            {
                var prevFg = Console.ForegroundColor;
                Console.ForegroundColor = outcomeColor;
                output.Write($"{summaryItem.Outcome,-28}");
                Console.ForegroundColor = prevFg;
            }
            else
            {
                output.Write($"{summaryItem.Outcome,-28}");
            }
            output.WriteLine($"  {summaryItem.Points,3}/{test.Points} pts");
            if (verbose)
            {
                if (summaryItem.Counters is not null)
                {
                    output.WriteLine($"        {summaryItem.Counters}");
                }
                if (!string.IsNullOrWhiteSpace(processOutput))
                {
                    output.WriteLine($"        --- dotnet test output ---");
                    foreach (var line in processOutput.Split('\n'))
                    {
                        output.WriteLine($"        {line.TrimEnd()}");
                    }
                    output.WriteLine($"        --- end of output ---");
                }
                if (!string.IsNullOrWhiteSpace(processError))
                {
                    if (useColors)
                    {
                        var errColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        output.WriteLine($"        --- dotnet test stderr ---");
                        foreach (var line in processError.Split('\n'))
                        {
                            output.WriteLine($"        {line.TrimEnd()}");
                        }
                        output.WriteLine($"        --- end of stderr ---");
                        Console.ForegroundColor = errColor;
                    }
                    else
                    {
                        output.WriteLine($"        --- dotnet test stderr ---");
                        foreach (var line in processError.Split('\n'))
                        {
                            output.WriteLine($"        {line.TrimEnd()}");
                        }
                        output.WriteLine($"        --- end of stderr ---");
                    }
                }
            }

            summary.SummaryItems.Add(summaryItem);
        }
        summary.Points += summary.SummaryItems.Sum(i => i.Points);

        // print per-submission total
        {
            var totalColor = summary.Points >= summary.MaximumPoints ? ConsoleColor.Green
                           : summary.Points > 0                      ? ConsoleColor.DarkYellow
                           : ConsoleColor.Red;
            if (useColors)
            {
                var prevFg = Console.ForegroundColor;
                Console.ForegroundColor = totalColor;
                output.WriteLine($"  -> {summary.Points}/{summary.MaximumPoints} pts total");
                Console.ForegroundColor = prevFg;
            }
            else
            {
                output.WriteLine($"  -> {summary.Points}/{summary.MaximumPoints} pts total");
            }
        }

        if (tests.Cleanup is not null)
        {
            if (verbose)
            {
                output.WriteLine($"    - running test cleanup with command: '{tests.Cleanup}'");
            }
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(tests.Cleanup.CommandName, tests.Cleanup.Arguments ?? string.Empty);
                psi.WorkingDirectory = answerDir.FullName;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                var p = Process.Start(psi);
                if (null != p)
                {
                    _ = p.StandardOutput.ReadToEndAsync();
                    _ = p.StandardError.ReadToEndAsync();
                    await p.WaitForExitAsync();
                    summary.CleanupExitCode = p.ExitCode;
                    if (tests.Cleanup.SuccessExitCode == p.ExitCode)
                    {
                        summary.Points += tests.Cleanup.Points ?? 0;
                    }
                    else
                    {
                        output.WriteLine($"\t-cleanup command '{tests.Cleanup}' on {answerDir.Name} exited with non-success code {p.ExitCode}");
                    }
                }
            }
            catch (Exception e)
            {
                output.WriteLine($"*****\nError executing the test cleanup command '{tests.Cleanup}' on {answerDir.Name}:\n{e.Message}\n*****");
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

        return localErrors;
    }

    private sealed class TeeTextWriter : TextWriter
    {
        private readonly TextWriter _console;
        private readonly TextWriter _file;

        public TeeTextWriter(TextWriter console, TextWriter file)
        {
            _console = console;
            _file = file;
        }

        public override Encoding Encoding => _console.Encoding;

        public override void Write(char value)
        {
            _console.Write(value);
            _file.Write(value);
        }

        public override void Write(string? value)
        {
            _console.Write(value);
            _file.Write(value);
        }

        public override void WriteLine(string? value)
        {
            _console.WriteLine(value);
            _file.WriteLine(value);
        }

        public override void WriteLine()
        {
            _console.WriteLine();
            _file.WriteLine();
        }

        public override void Flush()
        {
            _console.Flush();
            _file.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            // do not dispose either writer here — lifetime is managed by the caller
            base.Dispose(disposing);
        }
    }

    private void ReadTestResultsFromLogFile(DirectoryInfo submission, string logFile, TestRunSummaryItem summaryItem, string? testPath, bool verbose, TextWriter output)
    {
        var path = Path.Combine(submission.FullName, testPath, "TestResults", logFile);
        FileInfo source = new FileInfo(path);
        if (false == source.Exists)
        {
            if (verbose)
            {
                output.WriteLine($"*****\nTest results file '{path}' not found.\n*****");
            }
            summaryItem.Outcome = "Required code under test was not found. Test failed.";
            summaryItem.Points = 0;
            summaryItem.Outputs.Add(new TestRunOutput
            {
                Info = $"Required code under test was not found.",
                Message = $"Required code under test was not found or the test project could not be built, so the tests could not be run. Common reasons for this is incomplete code which leads to build failure.",
                StackTrace = string.Empty
            });
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
                var trOutput = tr.Output.FirstOrDefault();
                var errorInfo = trOutput.ErrorInfo;
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
            output.WriteLine($"!FAILED to convert file {source.Name}.\n\n{ex.Message}");
            Console.ForegroundColor = cc;
            summaryItem.Outcome = "Test results parsing failed";
            summaryItem.Points = 0;
            summaryItem.Outputs.Add(new TestRunOutput
            {
                Info = $"Failed to parse test results file '{source.Name}'",
                Message = ex.Message,
                StackTrace = ex.StackTrace ?? string.Empty
            });
        }

    }
}
