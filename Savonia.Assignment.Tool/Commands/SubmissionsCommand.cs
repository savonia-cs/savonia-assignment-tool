using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsCommand : Command
{
    public SubmissionsCommand() : base("submissions", "Work with multiple solutions sent as answers")
    {
        AddCommand(new SubmissionsUnpackCommand());
        AddCommand(new SubmissionsTestCommand());
        AddCommand(new SubmissionsPackCommand());
        AddCommand(new SubmissionsListCommand());
    }
}

