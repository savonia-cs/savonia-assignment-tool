using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;

namespace Savonia.Assignment.Tool.Commands;

public class MoodleReadCommand : Command
{
    public MoodleReadCommand() : base("read", "Read Moodle CSV file.")
    {
        var csvOutputOption = new Option<string>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file.",
            getDefaultValue: () => "moodleresult.csv");
        csvOutputOption.AddAlias("-o");

        Add(csvOutputOption);
        Add(CommonOptions.SourceCsvFileOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForOption(csvOutputOption)!,
                                 context.ParseResult.GetValueForOption(CommonOptions.SourceCsvFileOption)!,
                                 context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(string output,
                        FileInfo input,
                        bool verbose)
    {
        Console.WriteLine($"Opening file {input.Name}");
        List<List<string>> csvContent = new List<List<string>>();
        using (var streamRdr = new StreamReader(input.OpenRead()))
        {
            var csvReader = new CsvReader(streamRdr, ",");
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
