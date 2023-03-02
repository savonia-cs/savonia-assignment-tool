using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsListCommand : Command
{
    public SubmissionsListCommand() : base("list", "List submission folders in defined 'path'. The list numbers can be used to select submissions to include in testing.")
    {
        this.SetHandler(async (path, verbose) =>
            {
                await Handle(path!, verbose);
            },
            GlobalOptions.SourcePathOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path, bool verbose)
    {
        Directory.SetCurrentDirectory(path.FullName);
        var answerDirectories = path.GetDirectories().OrderBy(d => d.Name).ToArray();
        for (int i = 0; i < answerDirectories.Length; i++)
        {
            Console.WriteLine($"{i + 1, 4}. {answerDirectories[i].Name}");
        }
    }
}

