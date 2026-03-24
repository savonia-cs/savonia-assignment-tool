using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;
using System.Text.RegularExpressions;
using Savonia.Assignment.Tool.Commands.Learn.Models;

namespace Savonia.Assignment.Tool.Commands.Learn;

public class LearnCheckHtmlContentCommand : Command
{

    public LearnCheckHtmlContentCommand() : base("content", "Check that required content are found from a web resource.")
    {
        var requirementsArgument = new Argument<FileInfo>("requirementsJsonFile")
        {
            Description = "JSON file containing the rules for the resource content.",
            DefaultValueFactory = parseResult =>
            {
                if (parseResult.Tokens.Count == 0)
                {
                    parseResult.AddError("Requirements JSON file is not specified.");
                    return null;
                }
                string? filePath = parseResult.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    parseResult.AddError("Requirements JSON file does not exist");
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            }
        };

        var outputOption = new Option<string?>("--output", ["-o"])
        {
            Description = "Output csv file. This will overwrite possible existing file. By default the output file is named the same as source file with \"-result.csv\" appended to the end.",
            DefaultValueFactory = _ => null
        };

        var resourcesOutputOption = new Option<string?>("--resources-output-folder")
        {
            Description = "Folder for loaded resource files. Can be absolute or relative path. By default the resources are not saved.",
            DefaultValueFactory = _ => null
        };

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

        var nameFieldOption = new Option<string>("--name-field")
        {
            Description = "Field where the name is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 2 which is default field for Moodle LMS export file for name.",
            DefaultValueFactory = _ => "2"
        };

        var resourceFieldOption = new Option<string>("--resource-field")
        {
            Description = "Field where the resource URL is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 9 which is default field for Moodle LMS export file for assignment submissions text.",
            DefaultValueFactory = _ => "9"
        };

        var gradeFieldOption = new Option<string>("--grade-field")
        {
            Description = "Field where the grade is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 5 which is default field for Moodle LMS export file for assignment grade.",
            DefaultValueFactory = _ => "5"
        };

        var gradeOption = new Option<string>("--grade")
        {
            Description = "Grade value to write when all requirements are met. Defaults to number 1.",
            DefaultValueFactory = _ => "1"
        };

        var commentsFieldOption = new Option<string>("--comments-field")
        {
            Description = "Field where the comments is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 11 which is default field for Moodle LMS export file for assignment feedback comments.",
            DefaultValueFactory = _ => "11"
        };

        var fieldFiltersOption = new Option<List<string>>("--field-filters")
        {
            Description = "Field regex filter. Set in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d+ to select first numbers from field 3). Use predefined regex filter values: URL to filter urls or regex name(s) defined in --regexes option. Leave to empty to select field data as is.",
            DefaultValueFactory = _ => [],
            AllowMultipleArgumentsPerToken = true
        };

        var regexInputOption = new Option<FileInfo?>("--regexes")
        {
            Description = "A JSON file containing key-value pair (a dictionary) of regexes to filter/parse CSV column values. Key is the regex \"name\" and value is the regex \"pattern\".",
            DefaultValueFactory = result =>
            {
                if (result.Tokens.Count == 0)
                {
                    // no regexes defined
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.AddError("Regexes JSON file does not exist");
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            },
        };

        Add(CommonArguments.SourceCsvFileArgument);
        Add(requirementsArgument);
        Add(outputOption);
        Add(resourcesOutputOption);
        Add(inputCsvHasHeaderOption);
        Add(inputCsvDelimiterOption);
        Add(nameFieldOption);
        Add(resourceFieldOption);
        Add(gradeFieldOption);
        Add(gradeOption);
        Add(commentsFieldOption);
        Add(fieldFiltersOption);
        Add(regexInputOption);

        this.SetAction(async parseResult =>
            {
                FileInfo input = parseResult.GetValue(CommonArguments.SourceCsvFileArgument)!;
                string? output = parseResult.GetValue(outputOption) ?? $"{Path.GetFileNameWithoutExtension(input.Name)}-result.csv";

                await Handle(input, output,
                                parseResult.GetValue(requirementsArgument)!,
                                parseResult.GetValue(resourcesOutputOption),
                                parseResult.GetValue(inputCsvDelimiterOption)!,
                                parseResult.GetValue(inputCsvHasHeaderOption),
                                parseResult.GetValue(nameFieldOption)!,
                                parseResult.GetValue(resourceFieldOption)!,
                                parseResult.GetValue(gradeFieldOption)!,
                                parseResult.GetValue(gradeOption)!,
                                parseResult.GetValue(commentsFieldOption)!,
                                parseResult.GetValue(fieldFiltersOption)!,
                                parseResult.GetValue(regexInputOption),
                                parseResult.GetValue(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(FileInfo input, string? output,
                        FileInfo requirementsJsonFile,
                        string? resourcesOutputFolder,
                        string inputDelimiter, bool inputHasHeader,
                        string nameField, string resourceField, string gradeField, string grade, string commentsField,
                        List<string> fieldFilters, FileInfo? regexes, bool verbose)
    {
        // set working directory
        Directory.SetCurrentDirectory(Path.GetDirectoryName(input.FullName)!);
        bool writeResources = !string.IsNullOrEmpty(resourcesOutputFolder);
        if (writeResources)
        {
            Directory.CreateDirectory(resourcesOutputFolder!);
        }

        Console.WriteLine($"Check web content for users");

        var csvContent = input.ReadCsv(inputDelimiter);
        var headerRow = csvContent.GetHeaderRow(inputHasHeader);
        var requirements = await System.Text.Json.JsonSerializer.DeserializeAsync<ContentRules>(File.OpenRead(requirementsJsonFile.FullName));

        List<List<string>> outputContent = new List<List<string>>(csvContent);

        await regexes.LoadRegexes();
        var fieldRegexes = fieldFilters.GetFieldRegexes(headerRow);

        ContentRules rules = System.Text.Json.JsonSerializer.Deserialize<ContentRules>(File.OpenRead(requirementsJsonFile.FullName)
                                    , new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        if (rules is null)
        {
            var dc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Deserialization of requirements failed. Check the JSON file '{requirementsJsonFile.FullName}'.");
            Console.ForegroundColor = dc;
            return;
        }
        else
        {
            if (verbose)
            {
                Console.WriteLine($"Loaded {rules.StaticRules.Count} static and {rules.DynamicRules.Count} dynamic rules.");
            }
        }

        WebContentReader reader = new WebContentReader();

        int nameFieldIndex = headerRow.GetFieldIndex(nameField);
        int resourceFieldIndex = headerRow.GetFieldIndex(resourceField);
        int gradeFieldIndex = headerRow.GetFieldIndex(gradeField);
        int commentsFieldIndex = headerRow.GetFieldIndex(commentsField);
        int start = inputHasHeader ? 1 : 0;
        var defaultColor = Console.ForegroundColor;
        for (int i = start; i < csvContent.Count; i++)
        {
            string name = csvContent[i][nameFieldIndex].GetFieldValue(nameFieldIndex, fieldRegexes).Trim();
            string resource = csvContent[i][resourceFieldIndex].GetFieldValue(resourceFieldIndex, fieldRegexes).Trim();
            if (string.IsNullOrEmpty(resource))
            {
                continue;
            }
            var result = await reader.GetResourceAsync(resource);
            if (null == result.content)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t- {name}: {resource} resulted in {result.code}, {result.reason}.");
                Console.ForegroundColor = defaultColor;
                outputContent[i][commentsFieldIndex] = $"Request for {resource} failed with {result.code}, {result.reason}.";
                outputContent[i][gradeFieldIndex] = "0";
                continue;
            }
            if (writeResources)
            {
                string resourceFileName = Path.Combine(resourcesOutputFolder!, $"{name}.html");
                File.WriteAllText(resourceFileName, result.content);
            }
            var (allRequirementsMet, missingRequirements) = CheckRequirements(result.content, csvContent[i], headerRow, rules, verbose);
            if (allRequirementsMet)
            {
                if (verbose)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t- User {name} has all required content.");
                    Console.ForegroundColor = defaultColor;
                }
                outputContent[i][gradeFieldIndex] = grade;
            }
            else
            {
                if (verbose)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t- User {name} does not have all required content.");
                    Console.ForegroundColor = defaultColor;
                }
                outputContent[i][commentsFieldIndex] = $"{string.Join(", ", missingRequirements.Select(m => $"{m.Value}"))}";
                outputContent[i][gradeFieldIndex] = "0";
            }
        }

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        output!.WriteCsv(outputContent, inputDelimiter);
    }

    private (bool allRequirementsMet, Dictionary<string, string> missingRequirements) CheckRequirements(string content, List<string> userContent, List<string> headerRow, ContentRules rules, bool verbose)
    {
        Dictionary<string, string> missingRequirements = new Dictionary<string, string>();
        foreach (var rule in rules.StaticRules)
        {
            if (!rule.CheckRule(content))
            {
                missingRequirements.Add(rule.Name, rule.FeedbackOnFail);
            }
        }
        foreach (var rule in rules.DynamicRules)
        {
            var sourceFieldIndex = headerRow.GetFieldIndex(rule.SourceField);
            var sourceValue = userContent[sourceFieldIndex];
            if (verbose)
            {
                Console.WriteLine($"\t- Checking dynamic rule {rule.Name} with value {sourceValue}.");
            }
            if (!rule.CheckRule(content, sourceValue))
            {
                missingRequirements.Add(rule.Name, rule.FeedbackOnFail);
            }
        }
        return missingRequirements.Count == 0 ? (true, missingRequirements) : (false, missingRequirements);
    }
}
