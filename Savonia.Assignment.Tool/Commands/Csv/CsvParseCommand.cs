using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;
using System.Text.RegularExpressions;

namespace Savonia.Assignment.Tool.Commands.Csv;

public class CsvParseCommand : Command
{
    public CsvParseCommand() : base("parse", "Parse a CSV file with selected fields and possible Regex filters and output to another CSV file.")
    {
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

        var outputCsvDelimiterOption = new Option<string>("--output-delimiter")
        {
            Description = "Delimiter for the output CSV file.",
            DefaultValueFactory = _ => ","
        };

        var csvOutputOption = new Option<string?>("--output", ["-o"])
        {
            Description = "Output csv file. This will overwrite possible existing file. By default the output file is named the same as source file with \"-result.csv\" appended to the end.",
            DefaultValueFactory = _ => null
        };

        var regexInputOption = new Option<FileInfo?>("--regexes")
        {
            Description = "A JSON file containing key-value pair (a dictionary) of regexes to filter/parse CSV column values. Key is the regex \"name\" and value is the regex \"pattern\".",
            DefaultValueFactory = _ => null,
        };
        regexInputOption.Validators.Add(result =>
        {
                if (result.Tokens.Count == 0)
                {
                    // no regexes defined
                    return;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.AddError("Regexes JSON file does not exist");
                    return;
                }
        });

        var selectedFieldsOption = new Option<List<string>>("--fields")
        {
            Description = "Fields to select from the input CSV file to be written to output CSV file. Use one-based (i.e. first field is one (1)) field number or field header to select. Leave to empty to select all fields.",
            DefaultValueFactory = _ => [], 
            AllowMultipleArgumentsPerToken = true
        };

        var fieldFiltersOption = new Option<List<string>>("--field-filters")
        {
            Description = "Field regex filter. Set in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d+ to select first numbers from field 3). Use predefined regex filter values: URL to filter urls or regex name(s) defined in --regexes option. Leave to empty to select field data as is.",
            DefaultValueFactory = _ => [],
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourceCsvFileArgument);
        Add(inputCsvDelimiterOption);
        Add(outputCsvDelimiterOption);
        Add(inputCsvHasHeaderOption);
        Add(csvOutputOption);
        Add(selectedFieldsOption);
        Add(fieldFiltersOption);
        Add(regexInputOption);

        this.SetAction(async parseResult =>
            {
                FileInfo input = parseResult.GetValue(CommonArguments.SourceCsvFileArgument)!;
                string output = parseResult.GetValue(csvOutputOption) ?? $"{Path.GetFileNameWithoutExtension(input.Name)}-result.csv";

                await Handle(output,
                                 input,
                                 parseResult.GetValue(inputCsvDelimiterOption),
                                 parseResult.GetValue(outputCsvDelimiterOption),
                                 parseResult.GetValue(inputCsvHasHeaderOption),
                                 parseResult.GetValue(selectedFieldsOption),
                                 parseResult.GetValue(fieldFiltersOption),
                                 parseResult.GetValue(regexInputOption),
                                 parseResult.GetValue(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(string output,
                        FileInfo input,
                        string inputDelimiter,
                        string outputDelimiter,
                        bool inputHasHeader,
                        List<string> selectedFields,
                        List<string> fieldFilters,
                        FileInfo? regexInput,
                        bool verbose)
    {
        // set working directory
        Directory.SetCurrentDirectory(Path.GetDirectoryName(input.FullName)!);

        Console.WriteLine($"Reading from file {input.Name} and writing to {output}");

        // read the whole file as rows and columns
        List<List<string>> csvContent = input.ReadCsv(inputDelimiter);

        // // get header row
        List<string> headerRow = csvContent.GetHeaderRow(inputHasHeader);

        int counter = 1;
        if (verbose)
        {
            Console.WriteLine($"{(csvContent.Count - (inputHasHeader ? 1 : 0)),4} {string.Join(", ", headerRow)}");
            foreach (var item in csvContent.Skip(inputHasHeader ? 1 : 0))
            {
                Console.WriteLine($"{counter++,4}: {string.Join(", ", item)}");
            }
        }
        var fieldIndexes = GetSelectedFieldIndexes(headerRow, selectedFields, csvContent);
        await regexInput.LoadRegexes();
        var fieldRegexes = fieldFilters.GetFieldRegexes(headerRow);

        if (File.Exists(output))
        {
            File.Delete(output);
        }
        if (verbose)
        {
            Console.WriteLine($"\nwriting to {output}...");
        }

        
        using (var sw = new StreamWriter(File.OpenWrite(output)))
        {
            var csvWriter = new CsvWriter(sw, outputDelimiter);
            foreach (var row in csvContent)
            {
                foreach (var colIndex in fieldIndexes)
                {
                    csvWriter.WriteField(row[colIndex].GetFieldValue(colIndex, fieldRegexes));
                }
                csvWriter.NextRecord();
            }
        }
    }


    private List<int> GetSelectedFieldIndexes(List<string> headerRow, IEnumerable<string> selectedFields, List<List<string>> csvContent)
    {
        var fieldIndexes = new List<int>();
        if (selectedFields.Any())
        {
            int fieldIndex = -1;
            foreach (var item in selectedFields)
            {
                fieldIndex = headerRow.GetFieldIndex(item);
                if (fieldIndex > -1)
                {
                    fieldIndexes.Add(fieldIndex);
                }
            }
        }
        else
        {
            // all fields to output
            fieldIndexes = Enumerable.Range(0, headerRow.Count).ToList();
        }
        return fieldIndexes;
    }


}
