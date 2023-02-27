using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;

namespace Savonia.Assignment.Tool.Commands;

public class CsvReadCommand : Command
{
    public CsvReadCommand() : base("read", "Read a CSV file.")
    {
        this.IsHidden = true;

        var inputCsvHasHeaderOption = new Option<bool>(
            name: "--input-has-header",
            description: "Set to true when the input CSV file has header row.",
            getDefaultValue: () => true);

        var inputCsvDelimeterOption = new Option<string>(
            name: "--input-delimiter",
            description: "Delimiter for the input CSV file.",
            getDefaultValue: () => ",");

        AddOption(inputCsvHasHeaderOption);
        AddOption(inputCsvDelimeterOption);
        AddOption(CommonOptions.SourceCsvFileOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForOption(CommonOptions.SourceCsvFileOption)!,
                                context.ParseResult.GetValueForOption(inputCsvDelimeterOption)!,
                                context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(FileInfo input, string inputDelimiter, bool inputHasHeader, bool verbose)
    {
        Console.WriteLine($"Opening file {input.Name}");
        List<List<string>> csvContent = new List<List<string>>();
        using (var streamRdr = new StreamReader(input.OpenRead()))
        {
            var csvReader = new CsvReader(streamRdr, inputDelimiter);
            while (csvReader.Read())
            {
                List<string> row = new List<string>(csvReader.FieldsCount);
                for (int i = 0; i < csvReader.FieldsCount; i++)
                {
                    string val = csvReader[i];
                    row.Add(val);
                }
                csvContent.Add(row);
            }
        }
        int counter = 1;
        foreach (var item in csvContent)
        {
            Console.WriteLine($"{counter++,4}: ({item.Count}) {string.Join(", ", item)}");
        }
    }
}