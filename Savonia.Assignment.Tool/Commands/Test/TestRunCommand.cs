using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;
using NReco.Csv;
using System.Text.RegularExpressions;

namespace Savonia.Assignment.Tool.Commands.Test;

public class TestRunCommand : Command
{
    public TestRunCommand() : base("run", "Run tests for selected submissions")
    {
        // Add(CommonArguments.SourcePathArgument);
        // Add(CommonArguments.TestPathArgument);
        // Add(CommonArguments.OutputPathArgument);
        // AddOption(new Option<bool>("--no-compile", "Do not compile the source code before running tests."));
        // AddOption(new Option<bool>("--no-run", "Do not run the tests."));
        // AddOption(new Option<bool>("--no-clean", "Do not clean the output folder before running tests."));
        // AddOption(new Option<bool>("--no-restore", "Do not restore the NuGet packages before running tests."));


        // this.SetHandler(async (path, verbose) =>
        //     {
        //         await Handle(path!, verbose);
        //     },
        //     CommonArguments.SourcePathArgument, GlobalOptions.VerboseOption);
    }

    async Task Handle(string output,
                        FileInfo input,
                        string inputDelimiter,
                        string outputDelimiter,
                        bool inputHasHeader,
                        List<string> selectedFields,
                        List<string> fieldFilters,
                        FileInfo? regexInput,
                        bool verbose)
    {
        // set working directory
        Directory.SetCurrentDirectory(Path.GetDirectoryName(input.FullName)!);
    }

}
