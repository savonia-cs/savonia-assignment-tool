using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class HashCommand : Command
{
    public HashCommand() : base("hash", "Create hashes from files and operate on them.")
    {
        AddCommand(new HashCreateCommand());
        AddCommand(new HashCompareCommand());
        AddCommand(new HashOpenCommand());
    }

    internal static async Task<List<List<string>>> ReadCsvFile(FileInfo file)
    {
        List<List<string>> data = new List<List<string>>();
        using (var fs = file.OpenRead())
        using (StreamReader sr = new StreamReader(fs))
        {
            string content = await sr.ReadToEndAsync();
            content = content.Replace("\r", "");
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(','); // TODO: handle cases where column content contains comma (,)
                data.Add(columns.Select(c => c.Trim('"')).ToList());
            }
        }
        return data;
    }

}

