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
using Savonia.Assignment.Tool.Commands.Folders;

namespace Savonia.Assignment.Tool;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Savonia tool for assignments")
        {
            new SolutionCommand(),
            new SubmissionsCommand(),
            new HashCommand(),
            new CsvCommand(),
            new FilesCommand(),
            new FoldersCommand(),
            new TestCommand(),
            new LearnCommand()
        };

        rootCommand.Options.Add(GlobalOptions.VerboseOption);

        ParseResult parseResult = rootCommand.Parse(args);
        return await parseResult.InvokeAsync();
    }
}

