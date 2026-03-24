using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsTestCopyCommand : Command
{
    // savoniatool submissions test copy <testHarnessPath> <submissionPath> --selected-submissions 1-10 --test-harness-target tests --includes *.csproj --excludes bin,obj,TestResults,src,solution

    public SubmissionsTestCopyCommand() : base("copy", "Copy test harness or other assets to selected submissions.")
    {

        var assetsPathArgument = new Argument<DirectoryInfo>("assetPath")
        {
            Description = "Assets path from where to copy the files and folders to each submission folder."
        };

        assetsPathArgument.Validators.Add(result =>
        {
            var path = result.GetValue(assetsPathArgument).FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.AddError($"Assets path '{path}' does not exist");
            }
        });

        var submissionsPathArgument = new Argument<DirectoryInfo>("submissionPath")
        {
            Description = "Path to submission directory where to copy the test harness to each submission folder.",
            DefaultValueFactory = _ => new DirectoryInfo(Directory.GetCurrentDirectory())
        };

        submissionsPathArgument.Validators.Add(result =>
        {
            var path = result.GetValue(submissionsPathArgument).FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.AddError($"Submissions path '{path}' does not exist");
            }
        });

        var testHarnessTargetOption = new Option<string?>("--test-harness-target")
        {
            Description = "Target directory in submissions folder to where the test harness is copied. Default is '' (i.e. the submission folder)."
        };

        var selectedSubmissionsOption = new Option<List<string>?>("--selected-submissions")
        {
            Description = "Set index number of submission folders to copy the test harness to. Use submissions list command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            DefaultValueFactory = parseResult => [],
            AllowMultipleArgumentsPerToken = true
        };

        Add(assetsPathArgument);
        Add(submissionsPathArgument);
        Add(testHarnessTargetOption);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);
        Add(selectedSubmissionsOption);

        this.SetAction(async parseResult =>
        {
            await Handle(parseResult.GetValue(assetsPathArgument)!,
                            parseResult.GetValue(submissionsPathArgument)!,
                            parseResult.GetValue(testHarnessTargetOption),
                            parseResult.GetValue(CommonOptions.IncludesOption),
                            parseResult.GetValue(CommonOptions.ExcludesOption),
                            parseResult.GetValue(selectedSubmissionsOption),
                            parseResult.GetValue(GlobalOptions.VerboseOption));
        });
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
