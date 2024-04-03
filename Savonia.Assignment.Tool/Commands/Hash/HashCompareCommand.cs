using System.CommandLine;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Hash;

public class HashCompareCommand : Command
{
    public HashCompareCommand() : base("compare", "Compare hashes from source file.")
    {
        var csvOutputArgument = new Argument<string?>(
            name: "compareOutput",
            description: "Output csv file. This will overwrite possible existing file. By default the output file is named the same as source file with \"-compare-result.csv\" appended to the end.",
            getDefaultValue: () => null);


        Add(CommonArguments.SourceCsvFileArgument);
        Add(csvOutputArgument);
        Add(HashCommand.HashIndexOption);

        this.SetHandler(async (input, output, hashIndex, verbose) =>
            {
                await Handle(input!, output ?? $"{Path.GetFileNameWithoutExtension(input!.Name)}-compare-result.csv", hashIndex, verbose);
            },
            CommonArguments.SourceCsvFileArgument, csvOutputArgument, HashCommand.HashIndexOption, GlobalOptions.VerboseOption);

    }

    async Task Handle(FileInfo file, string output, int? hashIndex, bool verbose)
    {
        // if hashIndex == null -> assume that hash value is in the last column

        if (false == file.Exists)
        {
            Console.WriteLine($"Source file \"{file.FullName}\" does not exist.");
            return;
        }
        if (verbose)
        {
            Console.WriteLine($"Reading hashes from source \"{file.Name}\"");
        }
        List<List<string>> data = await file.ReadCsv();
        if (null == hashIndex && data.Any())
        {
            // assume that hash value is in the last column
            hashIndex = data.First().Count() - 1;
        }
        var grouped = data.GroupBy(d => d[hashIndex.Value]);
        // list only those with same hashes
        var sameHashes = grouped.Where(g => g.Count() > 1);
        var cc = Console.ForegroundColor;
        if (sameHashes.Count() > 0)
        {
            using (var sw = File.CreateText(output))
            {
                foreach (var group in sameHashes)
                {
                    if (verbose)
                    {
                        Console.WriteLine($"- {group.Key}");
                    }
                    int counter = 1;
                    foreach (var item in group)
                    {
                        string line = string.Join(",", item.Select(i => $"\"{i}\""));
                        if (verbose)
                        {
                            Console.WriteLine($"{counter++,4}: {line}");
                        }
                        await sw.WriteLineAsync(line);
                    }
                    await sw.WriteLineAsync();
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"COLLISIONS! File \"{file.Name}\" contains {sameHashes.Count()} collisions.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File \"{file.Name}\" did not contain collisions.");
        }
        Console.ForegroundColor = cc;
    }
}
