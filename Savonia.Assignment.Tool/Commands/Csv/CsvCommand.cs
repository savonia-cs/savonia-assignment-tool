using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Csv;

public class CsvCommand : Command
{
    public CsvCommand() : base("csv", "Work with CSV (Comma-separated values) files")
    {
        AddCommand(new CsvParseCommand());
        AddCommand(new CsvReadCommand());
    }
}

