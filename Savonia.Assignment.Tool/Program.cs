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
    // common usage:
    // savoniatool solution pack --output allsrc.zip --excludes test tests bin obj --includes **/*.cs 
    //
    // savoniatool answers test --result-file "moodle.csv" --path ./ --test-harness "path-to-folder-with-tests" --source-filters "**/src/my_code.cs" --test-runner python --test-runner-command "python testall.py" --test-points 1 1 1 1 1
    // dotnet test result line regex: .*?\b.*?\bFailed:.*?\b, Passed:.*?\b, Skipped:.*?\b, Total:.*?\b, Duration:.*?\b.dll.*?
    //

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

