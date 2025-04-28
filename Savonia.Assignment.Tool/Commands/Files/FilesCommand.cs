using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Files;

public class FilesCommand : Command
{
    public FilesCommand() : base("files", "Work with files")
    {
        AddCommand(new FilesCopyCommand());
        AddCommand(new FilesPackCommand());
        AddCommand(new FilesUnpackCommand());
        AddCommand(new FilesDeleteCommand());
    }
}

