using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Learn;

public class LearnCommand : Command
{
    public LearnCommand() : base("learn", "Work with MS Learn and other content")
    {
        AddCommand(new LearnReadCommand());
        AddCommand(new LearnCheckCommand());
        AddCommand(new LearnCheckHtmlContentCommand());
       
    }
}

