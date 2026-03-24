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
        this.Hidden = true;

        var inputCsvHasHeaderOption = new Option<bool>("--input-has-header")
        {
            Description = "Set to true when the input CSV file has header row.",
            DefaultValueFactory = _ => true
        };

        var inputCsvDelimiterOption = new Option<string>("--input-delimiter")
        {
            Description = "Delimiter for the input CSV file.",
            DefaultValueFactory = _ => ","
        };

        Add(CommonArguments.SourceCsvFileArgument);
        Add(inputCsvHasHeaderOption);
        Add(inputCsvDelimiterOption);

        this.SetAction(async parseResult =>
            {
                await Handle(parseResult.GetValue(CommonArguments.SourceCsvFileArgument)!,
                                parseResult.GetValue(inputCsvDelimiterOption)!,
                                parseResult.GetValue(inputCsvHasHeaderOption),
                                parseResult.GetValue(GlobalOptions.VerboseOption));
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