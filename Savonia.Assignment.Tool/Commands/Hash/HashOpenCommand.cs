using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Hash;

public class HashOpenCommand : Command
{
    public HashOpenCommand() : base("open", "Open match groups with defined editor.")
    {
        var fileIndexOption = new Option<int?>("--file-index")
        {
            Description = "Column index (zero-based) for the file column. Null value assumes that file is in the first column.",
            DefaultValueFactory = _ => null
        };

        var editorOption = new Option<string>("--editor")
        {
            Description = "Editor executable name. The executable should be in the PATH environment variable.",
            DefaultValueFactory = _ => "code"
        };

        var editorParamsOption = new Option<string>("--editor-params")
        {
            Description = "Parameters for the editor executable.",
            DefaultValueFactory = _ => "-n"
        };

        Add(CommonArguments.SourceCsvFileArgument);
        Add(CommonArguments.SourcePathArgument);
        Add(HashCommand.HashIndexOption);
        Add(fileIndexOption);
        Add(editorOption);
        Add(editorParamsOption);

        this.SetAction(async parseResult =>
        {
            var file = parseResult.GetValue(CommonArguments.SourceCsvFileArgument)!;
            var workingDirectory = parseResult.GetValue(CommonArguments.SourcePathArgument)!;
            var hashIndex = parseResult.GetValue(HashCommand.HashIndexOption);
            var fileIndex = parseResult.GetValue(fileIndexOption);
            var editor = parseResult.GetValue(editorOption);
            var editorParams = parseResult.GetValue(editorParamsOption);
            var verbose = parseResult.GetValue(GlobalOptions.VerboseOption);

            await Handle(file, workingDirectory, hashIndex, fileIndex, editor, editorParams, verbose);
        });        
    }

    async Task Handle(FileInfo file, DirectoryInfo workingDirectory, int? hashIndex, int? fileIndex, string editor, string editorParams, bool verbose)
    {
        if (false == file.Exists)
        {
            Console.WriteLine($"Source file \"{file.FullName}\" does not exist.");
            return;
        }

        Directory.SetCurrentDirectory(workingDirectory.FullName);

        if (verbose)
        {
            Console.WriteLine($"Opening hash groups from source \"{file.Name}\" with editor \"{editor}\"");
        }
        List<List<string>> data = file.ReadCsv();
        if (null == hashIndex && data.Any())
        {
            // assume that hash value is in the last column
            hashIndex = data.First().Count() - 1;
        }
        // if fileIndex == null -> assume that file is in the first column
        fileIndex = fileIndex ?? 0;

        var grouped = data.GroupBy(d => d[hashIndex.Value]);
        var sameHashes = grouped.Where(g => g.Count() > 1);
        if (sameHashes.Count() > 0)
        {
            foreach (var group in sameHashes)
            {
                string filesToOpen = string.Join(" ", group.Select(line => $"\"{line[fileIndex.Value]}\""));

                if (verbose)
                {
                    Console.WriteLine($"- {group.Key}");
                    Console.WriteLine($"  {editor} {editorParams} {string.Join(" ", filesToOpen)}");
                }

                ProcessStartInfo psi = new ProcessStartInfo(editor, $"{editorParams} {string.Join(" ", filesToOpen)}");
                psi.UseShellExecute = true;
                psi.CreateNoWindow = true;
                Process.Start(psi);
            }
        }
        else
        {
            Console.WriteLine($"File \"{file.Name}\" did not contain collisions. Nothing to open.");
        }
    }
}


