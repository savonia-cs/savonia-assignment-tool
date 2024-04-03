using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Solution;

public class SolutionCommand : Command
{
    public SolutionCommand() : base("solution", "Work with your solution to an assignment")
    {
        AddCommand(new SolutionPackCommand());
    }
}
