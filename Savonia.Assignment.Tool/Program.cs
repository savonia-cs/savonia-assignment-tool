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
using Savonia.Assignment.Tool.Commands;

namespace Savonia.Assignment.Tool;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Savonia tool for assingments");
        rootCommand.AddGlobalOption(GlobalOptions.SourcePathOption);
        rootCommand.AddGlobalOption(GlobalOptions.VerboseOption);

        rootCommand.AddCommand(new SolutionCommand());
        rootCommand.AddCommand(new AnswersCommand());
        rootCommand.AddCommand(new HashCommand());

        return await rootCommand.InvokeAsync(args);
    }
}

