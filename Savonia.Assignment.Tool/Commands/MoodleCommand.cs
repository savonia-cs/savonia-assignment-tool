using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class MoodleCommand : Command
{
    public MoodleCommand() : base("moodle", "Work with Moodle files")
    {
        this.IsHidden = true;
        AddCommand(new MoodleReadCommand());
    }
}

