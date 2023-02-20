using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class MoodleCommand : Command
{
    public MoodleCommand() : base("moodle", "Work with Moodle files")
    {
        AddCommand(new MoodleParseCommand());
        AddCommand(new MoodleReadCommand());
    }
}

