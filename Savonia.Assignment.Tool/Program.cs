﻿using System;
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
        var rootCommand = new RootCommand("Savonia tool for assignments");
        rootCommand.AddGlobalOption(GlobalOptions.VerboseOption);

        rootCommand.AddCommand(new SolutionCommand());
        rootCommand.AddCommand(new SubmissionsCommand());
        rootCommand.AddCommand(new HashCommand());
        rootCommand.AddCommand(new CsvCommand());
        rootCommand.AddCommand(new FilesCommand());
        rootCommand.AddCommand(new TestCommand());


        return await rootCommand.InvokeAsync(args);
    }
}

