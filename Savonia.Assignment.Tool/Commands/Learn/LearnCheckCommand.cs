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
        var requirementsArgument = new Argument<FileInfo>("requirementsJsonFile")
        {
            Description = "JSON file containing required achievements as JSON key-value-pairs where the key is achievements type id and value is achievement title.",
            DefaultValueFactory = parseResult =>
            {
                if (parseResult.Tokens.Count == 0)
                {
                    parseResult.AddError("Requirements JSON file is not specified.");
                    return default;
                }
                string? filePath = parseResult.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    parseResult.AddError("Requirements JSON file does not exist");
                    return default;
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

        var usernameFieldOption = new Option<string>("--username-field")
        {
            Description = "Field where the username is read. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 9 which is default field for Moodle LMS export file for assingment submissions text.",
            DefaultValueFactory = _ => "9"
        };

        var gradeFieldOption = new Option<string>("--grade-field")
        {
            Description = "Field where the grade is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 5 which is default field for Moodle LMS export file for assingment grade.",
            DefaultValueFactory = _ => "5"
        };

        var gradeOption = new Option<string>("--grade")
        {
            Description = "Grade value to write when all requirements are met. Defaults to number 1.",
            DefaultValueFactory = _ => "1"
        };

        var commentsFieldOption = new Option<string>("--comments-field")
        {
            Description = "Field where the comments is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 11 which is default field for Moodle LMS export file for assingment feedback comments.",
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
            DefaultValueFactory = parseResult =>
            {
                if (parseResult.Tokens.Count == 0)
                {
                    // no regexes defined
                    return null;
                }
                string? filePath = parseResult.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    parseResult.AddError("Regexes JSON file does not exist");
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            }
        };

        Add(CommonArguments.SourceCsvFileArgument);
        Add(requirementsArgument);
        Add(outputOption);
        Add(inputCsvHasHeaderOption);
        Add(inputCsvDelimiterOption);
        Add(usernameFieldOption);
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
                                parseResult.GetValue(inputCsvDelimiterOption)!,
                                parseResult.GetValue(inputCsvHasHeaderOption),
                                parseResult.GetValue(usernameFieldOption)!,
                                parseResult.GetValue(gradeFieldOption)!,
                                parseResult.GetValue(gradeOption)!,
                                parseResult.GetValue(commentsFieldOption)!,
                                parseResult.GetValue(fieldFiltersOption)!,
                                parseResult.GetValue(regexInputOption),
                                parseResult.GetValue(GlobalOptions.VerboseOption));
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
