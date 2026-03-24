using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsCommand : Command
{
    public SubmissionsCommand() : base("submissions", "Work with multiple solutions sent as answers")
    {
        Add(new SubmissionsUnpackCommand());
        Add(new SubmissionsTestCommand());
        Add(new SubmissionsPackCommand());
        Add(new SubmissionsListCommand());
        Add(new SubmissionsOpenCommand());
    }
}

