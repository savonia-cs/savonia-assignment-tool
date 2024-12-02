using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Net.Http.Json;

namespace Savonia.Assignment.Tool.Commands.Learn.Models;

public class WebContentReader
{
    private static HttpClient client = new HttpClient();

    public async Task<(string? content, string? reason, int code)> GetResourceAsync(string url)
    {
        try 
        {
            var response = await client.GetAsync(url);
            string? content = null;
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            return (content, response.ReasonPhrase, (int)response.StatusCode);
        }
        catch (Exception e)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            Console.ForegroundColor = defaultColor;
            return (null, e.Message, 0);
        }
    }
}

