using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsOpenCommand : Command
{
    public const string HandledFileName = ".savoniatoolhandled";
    // savoniatool submissions open <sourcePath> --selected-submissions 1-10 --unhandled-only true --mark-handled true

    public SubmissionsOpenCommand() : base("open", "Open each submission in defined submissions folder one by one. Proceeds to the next submission when the editor is closed.")
    {
        var selectedSubmissionsOption = new Option<List<string>?>(
            name: "--selected-submissions",
            description: "Set index number of submission folders to run tests on. Use submissions list command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            getDefaultValue: () => new List<string> { })
        {
            AllowMultipleArgumentsPerToken = true
        };

        var openOnlyUnhandledOption = new Option<bool>(
            name: "--unhandled-only",
            description: "Open only submission within selected submissions that are not marked as handled. Set to 'false' to open all selected submissions.",
            getDefaultValue: () => true);

        var markAsHandledOption = new Option<bool>(
            name: "--mark-handled",
            description: "Mark submissions as handled when moving to next submissions.",
            getDefaultValue: () => true);

        var editorOption = new Option<string>(
            name: "--editor",
            description: "Editor executable name. The executable should be in the PATH environment variable.",
            getDefaultValue: () => "code");

        var editorParamsOption = new Option<string>(
            name: "--editor-params",
            description: "Parameters for the editor executable.",
            getDefaultValue: () => "-n -w");

        Add(CommonArguments.SourcePathArgument);
        Add(openOnlyUnhandledOption);
        Add(markAsHandledOption);
        Add(selectedSubmissionsOption);
        Add(editorParamsOption);
        Add(editorOption);

        this.SetHandler(async (path, selectedSubmissions, unhandledOnly, markHandled, editor, editorParams, verbose) =>
        {
            await Handle(path, selectedSubmissions, unhandledOnly, markHandled, editor, editorParams, verbose);
        },
        CommonArguments.SourcePathArgument, selectedSubmissionsOption, openOnlyUnhandledOption, markAsHandledOption, editorOption, editorParamsOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path,
                        List<string>? selectedSubmissions,
                        bool unhandledOnly,
                        bool markHandled,
                        string editor,
                        string editorParams,
                        bool verbose)
    {
        Directory.SetCurrentDirectory(path.FullName);
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);

        Console.WriteLine($"Opening submissions from folder '{path.Name}'");
        Console.WriteLine($"- contains {answerDirectories.Length} submission folders");
        if (unhandledOnly)
        {
            Console.WriteLine($"- opening only unhandled submissions from selected submissions");
        }
        else
        {
            Console.WriteLine($"- opening all selected submissions");
        }
        if (markHandled)
        {
            Console.WriteLine($"- will create {HandledFileName} file once the editor is closed for the handled submission");
        }
        Console.WriteLine($"- using editor '{editor}' with parameters '{editorParams}' to open each submission folder");
        Console.WriteLine();

        for (int i = 0; i < answerDirectories.Length; i++)
        {
            Console.WriteLine("Opening submission {0} of {1}", i + 1, answerDirectories.Length);
            DateTime? handledTime;
            if (unhandledOnly && IsHandled(answerDirectories[i], out handledTime))
            {
                Console.WriteLine("\tsubmission {0} was handled on {1}", i + 1, handledTime);
                continue;
            }
            await OpenSubmission(answerDirectories[i], editor, editorParams);
            if (markHandled)
            {
                File.WriteAllText(Path.Combine(answerDirectories[i].FullName, HandledFileName), DateTime.Now.ToString("O"));
            }
            if (i < answerDirectories.Length - 1)
            {
                Console.Write("\topen next submission? (Y/n) ");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y || key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
        }
    }

    private async Task OpenSubmission(DirectoryInfo directoryInfo, string editor, string editorParams)
    {
        ProcessStartInfo psi = new ProcessStartInfo(editor, $"{editorParams} \"{directoryInfo.FullName}\"");
        psi.UseShellExecute = true;
        psi.CreateNoWindow = true;
        var p = Process.Start(psi);
        await p.WaitForExitAsync();
    }

    private bool IsHandled(DirectoryInfo directoryInfo, out DateTime? handledTime)
    {
        var files = directoryInfo.GetFiles(HandledFileName);
        bool isHandled = files.Any();
        if (isHandled)
        {
            handledTime = files.First().LastWriteTime;
        }
        else
        {
            handledTime = null;
        }
        return isHandled;
    }
}
