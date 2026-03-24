using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Hash;

public class HashCommand : Command
{
    internal static readonly Option<int?> HashIndexOption;

    public HashCommand() : base("hash", "Create hashes from files and operate on them.")
    {
        Add(new HashCreateCommand());
        Add(new HashCompareCommand());
        Add(new HashOpenCommand());
    }

    static HashCommand()
    {
        HashIndexOption = new Option<int?>("--hash-index")
        {
            Description = "Column index (zero-based) for the hash column. Null value assumes that hash is in the last column.",
            DefaultValueFactory = _ => null
        };
    }
}

