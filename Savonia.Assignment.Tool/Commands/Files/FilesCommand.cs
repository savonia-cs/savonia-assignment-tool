using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Files;

public class FilesCommand : Command
{
    public FilesCommand() : base("files", "Work with files")
    {
        Add(new FilesCopyCommand());
        Add(new FilesPackCommand());
        Add(new FilesUnpackCommand());
        Add(new FilesDeleteCommand());
    }
}

