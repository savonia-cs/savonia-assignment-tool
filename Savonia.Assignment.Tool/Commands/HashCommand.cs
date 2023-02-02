using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class HashCommand : Command
{
    internal static readonly Option<int?> HashIndexOption;

    public HashCommand() : base("hash", "Create hashes from files and operate on them.")
    {
        AddCommand(new HashCreateCommand());
        AddCommand(new HashCompareCommand());
        AddCommand(new HashOpenCommand());
    }

    static HashCommand()
    {
        HashIndexOption = new Option<int?>(
            name: "--hash-index",
            description: "Column index (zero-based) for the hash column. Null value assumes that hash is in the last column.",
            getDefaultValue: () => null);
    }
}

