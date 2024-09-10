using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Net.Http.Json;

namespace Savonia.Assignment.Tool.Commands.Learn.Models;

public class MSLearnReader
{
    private static HttpClient client = new HttpClient();

    // provider username
    private const string ProfileUriTemplate = "https://learn.microsoft.com/api/profiles/{0}";
    // provider user id from user profile
    private const string AchievementUriTemplate = "https://learn.microsoft.com/api/achievements/user/{0}";

    public async Task<UserProfile?> GetUserProfileAsync(string username)
    {
        var uri = string.Format(ProfileUriTemplate, username);
        try 
        {
            var response = await client.GetFromJsonAsync<UserProfile>(uri);
            return response;
        }
        catch (Exception e)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            Console.ForegroundColor = defaultColor;
            return null;
        }
    }

    public async Task<UserAchievements?> GetUserAchievementsAsync(string userId)
    {
        var uri = string.Format(AchievementUriTemplate, userId);
        var response = await client.GetFromJsonAsync<UserAchievements>(uri);
        return response;
    }

}

