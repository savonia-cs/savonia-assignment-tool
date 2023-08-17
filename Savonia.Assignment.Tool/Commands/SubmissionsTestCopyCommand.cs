using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsTestCopyCommand : Command
{
    // savoniatool submissions test copy <testHarnessPath> <submissionPath> --selected-submissions 1-10 --test-harness-target tests --includes *.csproj --excludes bin,obj,TestResults,src,solution

    public SubmissionsTestCopyCommand() : base("copy", "Copy test harness to selected submissions.")
    {

        var testHarnessPathArgument = new Argument<DirectoryInfo>(
            name: "testHarnessPath",
            description: "Test harness path from where to copy the test harness to each submission folder."
            );

        testHarnessPathArgument.AddValidator(result =>
        {
            var path = result.GetValueForArgument(testHarnessPathArgument).FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.ErrorMessage = $"Test harness path '{path}' does not exist";
            }
        });

        var submissionsPathArgument = new Argument<DirectoryInfo>(
            name: "submissionPath",
            description: "Path to submission directory where to copy the test harness to each submission folder.",
            getDefaultValue: () => new DirectoryInfo(Directory.GetCurrentDirectory()));

        submissionsPathArgument.AddValidator(result =>
        {
            var path = result.GetValueForArgument(submissionsPathArgument).FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.ErrorMessage = $"Submissions path '{path}' does not exist";
            }
        });

        var testHarnessTargetOption = new Option<string?>(
            name: "--test-harness-target",
            description: "Target directory in submissions folder to where the test harness is copied. Default is '' (i.e. the submission folder)."
        );

        var selectedSubmissionsOption = new Option<List<string>?>(
            name: "--selected-submissions",
            description: "Set index number of submission folders to run tests on. Use submissions list command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            getDefaultValue: () => new List<string> { })
        {
            AllowMultipleArgumentsPerToken = true
        };

        Add(testHarnessPathArgument);
        Add(submissionsPathArgument);
        Add(testHarnessTargetOption);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);
        Add(selectedSubmissionsOption);

        this.SetHandler(async (testHarnessPath, submissionsPath, testHarnessTarget, includes, excludes, selectedSubmissions, verbose) =>
        {
            await Handle(testHarnessPath, submissionsPath, testHarnessTarget, includes, excludes, selectedSubmissions, verbose);
        },
        testHarnessPathArgument, submissionsPathArgument, testHarnessTargetOption, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, selectedSubmissionsOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo testHarnessPath,
                        DirectoryInfo submissionsPath,
                        string? testHarnessTarget,
                        List<string> includes,
                        List<string> excludes,
                        List<string>? selectedSubmissions,
                        bool verbose)
    {
        Directory.SetCurrentDirectory(submissionsPath.FullName);
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(submissionsPath, selectedSubmissions, verbose);

        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);
        var testHarnessFilesToCopy = matcher.GetResultsInFullPath(testHarnessPath.FullName).ToList();
        CopyTestHarness(testHarnessPath, testHarnessTarget, verbose, testHarnessFilesToCopy, answerDirectories);
    }

    private void CopyTestHarness(DirectoryInfo testHarness, string? testHarnessTarget, bool verbose, List<string> testHarnessFilesToCopy, DirectoryInfo[] answerDirectories)
    {
        Console.WriteLine($"Copying test harness files from {testHarness.FullName}");
        if (verbose)
        {
            foreach (var item in testHarnessFilesToCopy)
            {
                Console.WriteLine($"- {Path.GetRelativePath(testHarness.FullName, item)}");
            }
            Console.WriteLine($"to:");
        }

        foreach (var answerDir in answerDirectories)
        {
            if (verbose)
            {
                if (null != testHarnessTarget)
                {
                    Console.WriteLine($"- {answerDir.Name}/{testHarnessTarget}");
                }
                else
                {
                    Console.WriteLine($"- {answerDir.Name}");
                }
            }
            foreach (string file in testHarnessFilesToCopy)
            {
                string relativeFile = Path.GetRelativePath(testHarness.FullName, file);
                FileInfo sourceFile = new FileInfo(file);
                string destinationFile = Path.Combine(answerDir.FullName, testHarnessTarget ?? "", relativeFile);
                DirectoryInfo destinationPath = new DirectoryInfo(Path.GetDirectoryName(destinationFile));
                if (verbose)
                {
                    Console.WriteLine($"    {relativeFile}");
                }
                if (false == destinationPath.Exists)
                {
                    destinationPath.Create();
                }
                sourceFile.CopyTo(destinationFile, true);
            }
        }
    }
}
