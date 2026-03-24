using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Learn;

public class LearnCommand : Command
{
    public LearnCommand() : base("learn", "Work with MS Learn and other content")
    {
        Add(new LearnReadCommand());
        Add(new LearnCheckCommand());
        Add(new LearnCheckHtmlContentCommand());
       
    }
}

