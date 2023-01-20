using System;
using System.Reflection;
using System.IO.Compression;
using System.Collections.Concurrent;
using System.CommandLine;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool;

class Program
{
    // common usage:
    // savoniatool solution pack --output allsrc.zip --excludes test tests bin obj --includes **/*.cs 
    static async Task<int> Main(string[] args)
    {
        // path default is current working directory if no path is defined
        var sourcePathOption = new Option<DirectoryInfo?>(
            name: "--path",
            description: "Source path to pack",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return new DirectoryInfo("./");

                }
                string? path = result.Tokens.Single().Value;
                if (!Directory.Exists(path))
                {
                    result.ErrorMessage = "Directory does not exist";
                    return null;
                }
                else
                {
                    return new DirectoryInfo(path);
                }
            });

        var verboseOption = new Option<bool>(
            name: "--verbose",
            description: "Show verbose output.",
            getDefaultValue: () => false);
        verboseOption.AddAlias("-v");

        var outputOption = new Option<string>(
            name: "--output",
            description: "Output zip file. This will overwrite possible existing file.",
            getDefaultValue: () => "all.zip");
        outputOption.AddAlias("-o");

        var excludesOption = new Option<List<string>>(
            name: "--excludes",
            description: "Folders and files to exclude from the pack.",
            getDefaultValue: () => new List<string> { });
        excludesOption.AllowMultipleArgumentsPerToken= true;
 
        // by default include all files in all directories under the defined 'path'
        // more info: https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.filesystemglobbing.matcher?view=dotnet-plat-ext-7.0
        
        // NOTE for Linux: 
        // **/* pattern works on bash version 4+ and 'globstar' option needs to be set on (it is off by default)
        // To set globstar on use command: shopt -s globstar
        // Q/A: https://askubuntu.com/questions/1010707/how-to-enable-the-double-star-globstar-operator
        // if "select all" pattern is defined as:
        // A) --includes **/* 
        //      this will run the globing and the actual values of the globing result is set as includesOption values. On Linux the results depends on how the globstar option is set.
        // B) --includes "**/*" 
        //      this will set value **/* to the includesOption values AND this will work on Linux as intented regardles of BASH globstar setting status
        // The default value set here in code will work as intented (to select all files in all directories) on all .NET supported OSes.
        var includesOption = new Option<List<string>>(
            name: "--includes",
            description: "Files and patterns to include to the pack.",
            getDefaultValue: () => new List<string> { "**/*" });
        includesOption.AllowMultipleArgumentsPerToken= true;

        var rootCommand = new RootCommand("Savonia tool for assingments");
        rootCommand.AddGlobalOption(sourcePathOption);

        var solutionCommand = new Command("solution", "Work with your solution to an assignment");
        rootCommand.AddCommand(solutionCommand);

        var packCommand = new Command("pack", "Pack your solution to a zip file.")
            {
                outputOption,
                excludesOption,
                includesOption,
                verboseOption
            };
        solutionCommand.AddCommand(packCommand);

        packCommand.SetHandler(async (path, output, includes, excludes, verbose) =>
            {
                await PackSolution(path!, output, includes, excludes, verbose);
            },
            sourcePathOption, outputOption, includesOption, excludesOption, verboseOption);


        return await rootCommand.InvokeAsync(args);
    }

    internal static async Task PackSolution(DirectoryInfo path, 
                                            string output, 
                                            List<string> includes, 
                                            List<string> excludes,
                                            bool verbose)
    {
        // if 'output' is written to 'path' then set it to excludes list to allow packing all files (except the created output file)
        string outputExclude = output.Replace(path.FullName, string.Empty);
        excludes.Add(outputExclude);

        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);

        if (verbose)
        {
            Console.WriteLine($"Packing solution from folder '{path.Name}'");
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            Console.WriteLine();
            Console.WriteLine($"Result is packed to '{output}' file.");
        }

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        using (ZipArchive zipArchive = ZipFile.Open(output, ZipArchiveMode.Create))
        {

            foreach (string file in matcher.GetResultsInFullPath(path.FullName))
            {
                string relativeFile = file.Replace(path.FullName, "");
                if (verbose)
                {
                    Console.WriteLine($"- adding file: {relativeFile}");
                }
                zipArchive.CreateEntryFromFile(relativeFile, relativeFile);
            }
        }
    }
}

