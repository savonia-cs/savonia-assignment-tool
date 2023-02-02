using System.CommandLine;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class HashCompareCommand : Command
{
    public HashCompareCommand() : base("compare", "Compare hashes from source file.")
    {
        var csvOutputOption = new Option<string>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file.",
            getDefaultValue: () => "result.csv");
        csvOutputOption.AddAlias("-o");

        var hashIndexOption = new Option<int?>(
            name: "--hash-index",
            description: "Column index (zero-based) for the hash column. Null value assumes that hash is in the last column.",
            getDefaultValue: () => null);

        var sourceCsvFileOption = new Option<FileInfo>(
            name: "--source",
            description: "Source csv file.",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    result.ErrorMessage = "Source csv file is not specified. Use --source option.";
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "File does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });

        Add(sourceCsvFileOption);
        Add(csvOutputOption);
        Add(hashIndexOption);

        this.SetHandler(async (file, output, hashIndex, verbose) =>
            {
                await Handle(file!, output, hashIndex, verbose);
            },
            sourceCsvFileOption, csvOutputOption, hashIndexOption, GlobalOptions.VerboseOption);

    }

    internal static async Task Handle(FileInfo file, string output, int? hashIndex, bool verbose)
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
        List<List<string>> data = await HashCommand.ReadCsvFile(file);
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



