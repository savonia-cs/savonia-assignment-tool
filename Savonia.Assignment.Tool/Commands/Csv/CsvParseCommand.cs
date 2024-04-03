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
    private static readonly Dictionary<string, string> PredefinedRegexes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "URL", @"(https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])"}
    };

    public CsvParseCommand() : base("parse", "Parse a CSV file with selected fields and possible Regex filters and output to another CSV file.")
    {
        var inputCsvHasHeaderOption = new Option<bool>(
            name: "--input-has-header",
            description: "Set to true when the input CSV file has header row.",
            getDefaultValue: () => true);

        var inputCsvDelimiterOption = new Option<string>(
            name: "--input-delimiter",
            description: "Delimiter for the input CSV file.",
            getDefaultValue: () => ",");

        var outputCsvDelimiterOption = new Option<string>(
            name: "--output-delimiter",
            description: "Delimiter for the output CSV file.",
            getDefaultValue: () => ",");

        var csvOutputOption = new Option<string?>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file. By default the output file is named the same as source file with \"-result.csv\" appended to the end.",
            getDefaultValue: () => null);
        csvOutputOption.AddAlias("-o");

        var regexInputOption = new Option<FileInfo?>(
            name: "--regexes",
            description: "A JSON file containing key-value pair (a dictionary) of regexes to filter/parse CSV column values. Key is the regex \"name\" and value is the regex \"pattern\".",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    // no regexes defined
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "Regexes JSON file does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });

        var selectedFieldsOption = new Option<List<string>>(
            name: "--fields",
            description: "Fields to select from the input CSV file to be written to output CSV file. Use one-based (i.e. first field is one (1)) field number or field header to select. Leave to empty to select all fields.",
            getDefaultValue: () => new List<string>())
        {
            AllowMultipleArgumentsPerToken = true
        };

        var fieldFiltersOption = new Option<List<string>>(
            name: "--field-filters",
            description: "Field regex filter. Set in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d+ to select first numbers from field 3). Use predefined regex filter values: URL to filter urls or regex name(s) defined in --regexes option. Leave to empty to select field data as is.",
            getDefaultValue: () => new List<string>())
        {
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourceCsvFileArgument);
        AddOption(inputCsvDelimiterOption);
        AddOption(outputCsvDelimiterOption);
        AddOption(inputCsvHasHeaderOption);
        AddOption(csvOutputOption);
        AddOption(selectedFieldsOption);
        AddOption(fieldFiltersOption);
        AddOption(regexInputOption);

        this.SetHandler(async (context) =>
            {
                FileInfo input = context.ParseResult.GetValueForArgument(CommonArguments.SourceCsvFileArgument)!;
                string output = context.ParseResult.GetValueForOption(csvOutputOption) ?? $"{Path.GetFileNameWithoutExtension(input.Name)}-result.csv";

                await Handle(output,
                                 input,
                                 context.ParseResult.GetValueForOption(inputCsvDelimiterOption),
                                 context.ParseResult.GetValueForOption(outputCsvDelimiterOption),
                                 context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                 context.ParseResult.GetValueForOption(selectedFieldsOption),
                                 context.ParseResult.GetValueForOption(fieldFiltersOption),
                                 context.ParseResult.GetValueForOption(regexInputOption),
                                 context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
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

        // get header row
        List<string> headerRow = new List<string>();
        if (inputHasHeader)
        {
            headerRow = csvContent[0];
        }
        else
        {
            headerRow = Enumerable.Range(1, csvContent[0].Count).Select(i => i.ToString()).ToList();
        }


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
        await LoadRegexes(regexInput);
        var fieldRegexes = GetFieldRegexes(fieldFilters, headerRow);

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
                    csvWriter.WriteField(GetFieldValue(row[colIndex], colIndex, fieldRegexes));
                }
                csvWriter.NextRecord();
            }
        }
    }

    private async Task LoadRegexes(FileInfo? regexInput)
    {
        // load possible regexes from JSON file
        if (null != regexInput)
        {
            Dictionary<string, string>? regexes = await System.Text.Json.JsonSerializer.DeserializeAsync<Dictionary<string, string>>(regexInput.OpenRead());
            if (null != regexes && regexes.Count > 0)
            {
                foreach (var key in regexes.Keys)
                {
                    PredefinedRegexes[key] = regexes[key];
                }
            }
        }
    }

    private string GetFieldValue(string sourceFieldValue, int fieldIndex, Dictionary<int, string> fieldRegexes)
    {
        if (fieldRegexes.Count > 0 && fieldRegexes.ContainsKey(fieldIndex))
        {
            Match m = Regex.Match(sourceFieldValue, fieldRegexes[fieldIndex], RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return m.Value;
            }
        }
        return sourceFieldValue;
    }

    private Dictionary<int, string> GetFieldRegexes(List<string> fieldFilters, List<string> headerRow)
    {
        // parse field filters
        var fieldRegexes = new Dictionary<int, string>();
        if (fieldFilters != null)
        {
            for (int i = 0; i < fieldFilters.Count; i += 2)
            {
                // assume that values are in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d to select only numbers from field 3)
                if (fieldFilters.Count > i + 1)
                {
                    var fieldName = fieldFilters[i];
                    var regex = fieldFilters[i + 1];
                    int fieldIndex = GetFieldIndex(headerRow, fieldName);
                    if (fieldIndex > -1)
                    {
                        if (PredefinedRegexes.ContainsKey(regex))
                        {
                            regex = PredefinedRegexes[regex];
                        }
                        fieldRegexes.Add(fieldIndex, regex);
                    }
                }
            }
        }
        return fieldRegexes;
    }

    private List<int> GetSelectedFieldIndexes(List<string> headerRow, IEnumerable<string> selectedFields, List<List<string>> csvContent)
    {
        var fieldIndexes = new List<int>();
        if (selectedFields.Any())
        {
            int fieldIndex = -1;
            foreach (var item in selectedFields)
            {
                fieldIndex = GetFieldIndex(headerRow, item);
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

    private int GetFieldIndex(List<string> headerRow, string fieldName)
    {
        if (int.TryParse(fieldName, out int fieldNumber) && fieldNumber > 0 && fieldNumber <= headerRow.Count)
        {
            return fieldNumber - 1;
        }
        else
        {
            var fieldIndex = headerRow.IndexOf(fieldName);
            return fieldIndex;
        }
    }
}
