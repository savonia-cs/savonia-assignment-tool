using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;

namespace Savonia.Assignment.Tool.Commands.Csv;

public class CsvReadCommand : Command
{
    public CsvReadCommand() : base("read", "Read a CSV file and write content to terminal.")
    {
        this.IsHidden = true;

        var inputCsvHasHeaderOption = new Option<bool>(
            name: "--input-has-header",
            description: "Set to true when the input CSV file has header row.",
            getDefaultValue: () => true);

        var inputCsvDelimiterOption = new Option<string>(
            name: "--input-delimiter",
            description: "Delimiter for the input CSV file.",
            getDefaultValue: () => ",");

        Add(CommonArguments.SourceCsvFileArgument);
        AddOption(inputCsvHasHeaderOption);
        AddOption(inputCsvDelimiterOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForArgument(CommonArguments.SourceCsvFileArgument)!,
                                context.ParseResult.GetValueForOption(inputCsvDelimiterOption)!,
                                context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(FileInfo input, string inputDelimiter, bool inputHasHeader, bool verbose)
    {
        Console.WriteLine($"Opening file {input.Name}");
        var csvContent = input.ReadCsv(inputDelimiter);
        int counter = 1;
        foreach (var item in csvContent)
        {
            Console.WriteLine($"{counter++,4}: ({item.Count}) {string.Join(", ", item)}");
        }
    }
}