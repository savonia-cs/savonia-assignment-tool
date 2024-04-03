using System;
using System.Reflection;
using System.IO.Compression;
using System.Collections.Concurrent;
using System.CommandLine;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Savonia.Assignment.Tool.Commands.Csv;
using Savonia.Assignment.Tool.Commands.Files;
using Savonia.Assignment.Tool.Commands.Hash;
using Savonia.Assignment.Tool.Commands.Solution;
using Savonia.Assignment.Tool.Commands.Submissions;
using Savonia.Assignment.Tool.Commands.Test;
using Savonia.Assignment.Tool.Commands.Learn;

namespace Savonia.Assignment.Tool;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Savonia tool for assignments");
        rootCommand.AddGlobalOption(GlobalOptions.VerboseOption);

        rootCommand.AddCommand(new SolutionCommand());
        rootCommand.AddCommand(new SubmissionsCommand());
        rootCommand.AddCommand(new HashCommand());
        rootCommand.AddCommand(new CsvCommand());
        rootCommand.AddCommand(new FilesCommand());
        rootCommand.AddCommand(new TestCommand());
        rootCommand.AddCommand(new LearnCommand());


        return await rootCommand.InvokeAsync(args);
    }
}

