using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class TestCommand : Command
{
    public TestCommand() : base("test", "Work with (unit)testing")
    {
        AddCommand(new TestTrxToMdCommand());
        // AddCommand(new CsvReadCommand());
    }
}

