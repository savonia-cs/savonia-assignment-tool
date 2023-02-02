using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class HashOpenCommand : Command
{
    public HashOpenCommand() : base("open", "Open match groups with defined editor.")
    {
        var fileIndexOption = new Option<int?>(
            name: "--file-index",
            description: "Column index (zero-based) for the file column. Null value assumes that file is in the first column.",
            getDefaultValue: () => null);

        var editorOption = new Option<string>(
            name: "--editor",
            description: "Editor executable name. The executable should be in the PATH.",
            getDefaultValue: () => "code");

        var editorParamsOption = new Option<string>(
            name: "--editor-params",
            description: "Parameters for the editor executable.",
            getDefaultValue: () => "-n");

        Add(CommonOptions.SourceCsvFileOption);
        Add(HashCommand.HashIndexOption);
        Add(fileIndexOption);
        Add(editorOption);
        Add(editorParamsOption);

        this.SetHandler(async (file, hashIndex, fileIndex, editor, editorParams, verbose) =>
            {
                await Handle(file!, hashIndex, fileIndex, editor, editorParams, verbose);
            },
            CommonOptions.SourceCsvFileOption, HashCommand.HashIndexOption, fileIndexOption, editorOption, editorParamsOption, GlobalOptions.VerboseOption);        
    }

    internal async Task Handle(FileInfo file, int? hashIndex, int? fileIndex, string editor, string editorParams, bool verbose)
    {
        if (false == file.Exists)
        {
            Console.WriteLine($"Source file \"{file.FullName}\" does not exist.");
            return;
        }
        if (verbose)
        {
            Console.WriteLine($"Opening hash groups from source \"{file.Name}\" with editor \"{editor}\"");
        }
        List<List<string>> data = await file.ReadCsv();
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


