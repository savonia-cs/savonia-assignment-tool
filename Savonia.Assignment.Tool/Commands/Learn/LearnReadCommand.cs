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

public class LearnReadCommand : Command
{
    
    public LearnReadCommand() : base("read", "Read user's public MS Learn achievements.")
    {
        var usernameArgument = new Argument<string>("username", "The username of the user to read achievements for.");

        var outputOption = new Option<string?>(
            name: "--output",
            description: "Output json file. This will overwrite possible existing file.",
            getDefaultValue: () => null);
        outputOption.AddAlias("-o");

        Add(usernameArgument);
        AddOption(outputOption);

        this.SetHandler(async (context) =>
            {
                string input = context.ParseResult.GetValueForArgument(usernameArgument)!;
                string? output = context.ParseResult.GetValueForOption(outputOption);

                await Handle(input, output,
                                 context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(string username,
                        string? output,
                        bool verbose)
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
}
