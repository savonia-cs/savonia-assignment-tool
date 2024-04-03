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
            description: "Output csv file. This will overwrite possible existing file.",
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

        var commentsFieldOption = new Option<string>(
            name: "--comments-field",
            description: "Field where the comments is written. Use one-based (i.e. first field is one (1)) field number or field header to select. Defaults to field number 11 which is default field for Moodle LMS export file for assingment feedback comments.",
            getDefaultValue: () => "11");

        Add(CommonArguments.SourceCsvFileArgument);
        Add(requirementsArgument);
        AddOption(outputOption);
        AddOption(inputCsvHasHeaderOption);
        AddOption(inputCsvDelimiterOption);
        AddOption(usernameFieldOption);
        AddOption(gradeFieldOption);
        AddOption(commentsFieldOption);

        this.SetHandler(async (context) =>
            {
                FileInfo input = context.ParseResult.GetValueForArgument(CommonArguments.SourceCsvFileArgument)!;
                string? output = context.ParseResult.GetValueForOption(outputOption) ?? $"{Path.GetFileNameWithoutExtension(input.Name)}-result.csv";

                await Handle(input, output,
                                context.ParseResult.GetValueForArgument(requirementsArgument)!,
                                context.ParseResult.GetValueForOption(inputCsvDelimiterOption)!,
                                context.ParseResult.GetValueForOption(inputCsvHasHeaderOption),
                                context.ParseResult.GetValueForOption(usernameFieldOption),
                                context.ParseResult.GetValueForOption(gradeFieldOption),
                                context.ParseResult.GetValueForOption(commentsFieldOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(FileInfo input, string? output, FileInfo requirementsJsonFile, string inputDelimiter, bool inputHasHeader, string usernameField, string gradeField, string commentsField, bool verbose)
    {
        // set working directory
        Console.WriteLine($"Reading achievements for user {username}");

        MSLearnReader reader = new MSLearnReader();

        var userProfile = await reader.GetUserProfileAsync(username);

        if (null == userProfile)
        {
            Console.WriteLine($"Profile for user {username} not found.");
            return;
        }

        var achievements = await reader.GetUserAchievementsAsync(userProfile.UserId);
        if (null == achievements)
        {
            Console.WriteLine($"Achievements for user {username} not found.");
            return;
        }

        if (false == string.IsNullOrEmpty(output))
        {
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            await System.Text.Json.JsonSerializer.SerializeAsync(File.OpenWrite(output), achievements);
        }
        else
        {
            var learningPaths = achievements.Achievements.Where(a => a.Category == "learningpaths");
            var modules = achievements.Achievements.Where(a => a.Category == "modules");
            Console.WriteLine($"Learning Paths:\n{string.Join("\n", learningPaths.OrderBy(a => a.Title).Select(a => $"- {a}"))}");
            Console.WriteLine();
            Console.WriteLine($"Modules:\n{string.Join("\n", modules.OrderBy(a => a.Title).Select(a => $"- {a}"))}");
            Console.WriteLine();
            Console.WriteLine($"Total count: {achievements.TotalCount}");
        }
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
