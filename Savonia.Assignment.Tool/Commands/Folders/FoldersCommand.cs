using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Folders;

public class FoldersCommand : Command
{
    public FoldersCommand() : base("folders", "Work with folders")
    {
        AddCommand(new FoldersDeleteCommand());
    }
}

