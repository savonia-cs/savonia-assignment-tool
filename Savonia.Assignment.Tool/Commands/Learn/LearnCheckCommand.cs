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

public class LearnCheckCommand : Command
{

    public LearnCheckCommand() : base("check", "Check that required achievements are completed for users.")
    {
        var requirementsArgument = new Argument<FileInfo>(
            name: "requirementsJsonFile",
            description: "JSON file containing required achievements as JSON key-value-pairs where the key is achiements type id and value is achievement title.",
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

        var inputCsvHasHeaderOption = new Option<bool>(
            name: "--input-has-header",
            description: "Set to true when the input CSV file has header row.",
            getDefaultValue: () => true);

        var inputCsvDelimiterOption = new Option<string>(
            name: "--input-delimiter",
            description: "Delimiter for the input CSV file.",
            getDefaultValue: () => ",");

        var usernameFieldOption = new Option<string>(
            name: "--username-field",
            description: "Field where the username is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 9 which is default field for Moodle LMS export file for assingment submissions text.",
            getDefaultValue: () => "9");

        var gradeFieldOption = new Option<string>(
            name: "--grade-field",
            description: "Field where the grade is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 5 which is default field for Moodle LMS export file for assingment grade.",
            getDefaultValue: () => "5");

        var gradeOption = new Option<string>(
            name: "--grade",
            description: "Grade value to write when all requirements are met. Defaults to number 1.",
            getDefaultValue: () => "1");

        var commentsFieldOption = new Option<string>(
            name: "--comments-field",
            description: "Field where the comments is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 11 which is default field for Moodle LMS export file for assingment feedback comments.",
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
        AddOption(inputCsvHasHeaderOption);
        AddOption(inputCsvDelimiterOption);
        AddOption(usernameFieldOption);
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
                                context.ParseResult.GetValueForOption(inputCsvDelimiterOption)!,
                                context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                context.ParseResult.GetValueForOption(usernameFieldOption)!,
                                context.ParseResult.GetValueForOption(gradeFieldOption)!,
                                context.ParseResult.GetValueForOption(gradeOption)!,
                                context.ParseResult.GetValueForOption(commentsFieldOption)!,
                                context.ParseResult.GetValueForOption(fieldFiltersOption)!,
                                context.ParseResult.GetValueForOption(regexInputOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(FileInfo input, string? output, FileInfo requirementsJsonFile,
                        string inputDelimiter, bool inputHasHeader,
                        string usernameField, string gradeField, string grade, string commentsField,
                        List<string> fieldFilters, FileInfo? regexes, bool verbose)
    {
        // set working directory
        Directory.SetCurrentDirectory(Path.GetDirectoryName(input.FullName)!);

        Console.WriteLine($"Check achievements for users");

        var csvContent = input.ReadCsv(inputDelimiter);
        var headerRow = csvContent.GetHeaderRow(inputHasHeader);
        var requirements = await System.Text.Json.JsonSerializer.DeserializeAsync<Dictionary<string, string>>(File.OpenRead(requirementsJsonFile.FullName));

        List<List<string>> outputContent = new List<List<string>>(csvContent);

        await regexes.LoadRegexes();
        var fieldRegexes = fieldFilters.GetFieldRegexes(headerRow);

        MSLearnReader reader = new MSLearnReader();

        int usernameFieldIndex = headerRow.GetFieldIndex(usernameField);
        int gradeFieldIndex = headerRow.GetFieldIndex(gradeField);
        int commentsFieldIndex = headerRow.GetFieldIndex(commentsField);
        int start = inputHasHeader ? 1 : 0;
        var defaultColor = Console.ForegroundColor;
        for (int i = start; i < csvContent.Count; i++)
        {
            string username = csvContent[i][usernameFieldIndex].GetFieldValue(usernameFieldIndex, fieldRegexes).Trim();
            if (string.IsNullOrEmpty(username))
            {
                continue;
            }
            var profile = await reader.GetUserProfileAsync(username);
            if (null == profile)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t- Profile for user {username} not found.");
                Console.ForegroundColor = defaultColor;
                outputContent[i][commentsFieldIndex] = "Profile not found";
                outputContent[i][gradeFieldIndex] = "0";
                continue;
            }
            var userAchiements = await reader.GetUserAchievementsAsync(profile.UserId);
            if (null == userAchiements)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t- Achievements for user {username} not found.");
                Console.ForegroundColor = defaultColor;
                outputContent[i][commentsFieldIndex] = "Achievements not found";
                outputContent[i][gradeFieldIndex] = "0";
                continue;
            }
            var (allRequirementsMet, missingRequirements) = CheckRequirements(requirements!, userAchiements.Achievements);
            if (allRequirementsMet)
            {
                if (verbose)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t- User {username} ({profile.DisplayName}) has all required achievements.");
                    Console.ForegroundColor = defaultColor;
                }
                outputContent[i][gradeFieldIndex] = grade;
            }
            else
            {
                if (verbose)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t- User {username} does not have all required achievements.");
                    Console.ForegroundColor = defaultColor;
                }
                outputContent[i][commentsFieldIndex] = $"Missing: {string.Join(", ", missingRequirements.Select(m => $"{m.Value}"))}";
                outputContent[i][gradeFieldIndex] = "0";
            }
        }

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        output!.WriteCsv(outputContent, inputDelimiter);
    }

    private (bool allRequirementsMet, Dictionary<string, string> missingRequirements) CheckRequirements(Dictionary<string, string> requirements, Achievement[] achievements)
    {
        Dictionary<string, string> missingRequirements = new Dictionary<string, string>();
        foreach (var req in requirements)
        {
            if (!achievements.Any(a => a.TypeId.Equals(req.Key, StringComparison.OrdinalIgnoreCase)))
            {
                missingRequirements.Add(req.Key, req.Value);
            }
        }
        return missingRequirements.Count == 0 ? (true, missingRequirements) : (false, missingRequirements);
    }
}
