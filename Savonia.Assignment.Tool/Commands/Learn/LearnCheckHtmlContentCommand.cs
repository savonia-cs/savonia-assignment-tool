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
        var requirementsArgument = new Argument<FileInfo>(
            name: "requirementsJsonFile",
            description: "JSON file containing the rules for the resource content.",
            parse: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    result.ErrorMessage = "Requirements JSON file is not specified.";
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "Requirements JSON file does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });

        var outputOption = new Option<string?>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file. By default the output file is named the same as source file with \"-result.csv\" appended to the end.",
            getDefaultValue: () => null);
        outputOption.AddAlias("-o");

        var resourcesOutputOption = new Option<string?>(
            name: "--resources-output-folder",
            description: "Folder for loaded resource files. Can be absolute or relative path. By default the resources are not saved.",
            getDefaultValue: () => null);


        var inputCsvHasHeaderOption = new Option<bool>(
            name: "--input-has-header",
            description: "Set to true when the input CSV file has header row.",
            getDefaultValue: () => true);

        var inputCsvDelimiterOption = new Option<string>(
            name: "--input-delimiter",
            description: "Delimiter for the input CSV file.",
            getDefaultValue: () => ",");

        var nameFieldOption = new Option<string>(
            name: "--name-field",
            description: "Field where the name is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 2 which is default field for Moodle LMS export file for name.",
            getDefaultValue: () => "2");

        var resourceFieldOption = new Option<string>(
            name: "--resource-field",
            description: "Field where the resource URL is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 9 which is default field for Moodle LMS export file for assignment submissions text.",
            getDefaultValue: () => "9");

        var gradeFieldOption = new Option<string>(
            name: "--grade-field",
            description: "Field where the grade is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 5 which is default field for Moodle LMS export file for assignment grade.",
            getDefaultValue: () => "5");

        var gradeOption = new Option<string>(
            name: "--grade",
            description: "Grade value to write when all requirements are met. Defaults to number 1.",
            getDefaultValue: () => "1");

        var commentsFieldOption = new Option<string>(
            name: "--comments-field",
            description: "Field where the comments is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 11 which is default field for Moodle LMS export file for assignment feedback comments.",
            getDefaultValue: () => "11");

        var fieldFiltersOption = new Option<List<string>>(
            name: "--field-filters",
            description: "Field regex filter. Set in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d+ to select first numbers from field 3). Use predefined regex filter values: URL to filter urls or regex name(s) defined in --regexes option. Leave to empty to select field data as is.",
            getDefaultValue: () => new List<string>())
        {
            AllowMultipleArgumentsPerToken = true
        };

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

        Add(CommonArguments.SourceCsvFileArgument);
        Add(requirementsArgument);
        AddOption(outputOption);
        AddOption(resourcesOutputOption);
        AddOption(inputCsvHasHeaderOption);
        AddOption(inputCsvDelimiterOption);
        AddOption(nameFieldOption);
        AddOption(resourceFieldOption);
        AddOption(gradeFieldOption);
        AddOption(gradeOption);
        AddOption(commentsFieldOption);
        AddOption(fieldFiltersOption);
        AddOption(regexInputOption);

        this.SetHandler(async (context) =>
            {
                FileInfo input = context.ParseResult.GetValueForArgument(CommonArguments.SourceCsvFileArgument)!;
                string? output = context.ParseResult.GetValueForOption(outputOption) ?? $"{Path.GetFileNameWithoutExtension(input.Name)}-result.csv";

                await Handle(input, output,
                                context.ParseResult.GetValueForArgument(requirementsArgument)!,
                                context.ParseResult.GetValueForOption(resourcesOutputOption),
                                context.ParseResult.GetValueForOption(inputCsvDelimiterOption)!,
                                context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                context.ParseResult.GetValueForOption(nameFieldOption)!,
                                context.ParseResult.GetValueForOption(resourceFieldOption)!,
                                context.ParseResult.GetValueForOption(gradeFieldOption)!,
                                context.ParseResult.GetValueForOption(gradeOption)!,
                                context.ParseResult.GetValueForOption(commentsFieldOption)!,
                                context.ParseResult.GetValueForOption(fieldFiltersOption)!,
                                context.ParseResult.GetValueForOption(regexInputOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
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
                                    , new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true} )!;
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
