using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Files;

public class FilesDeleteCommand : Command
{
    // savoniatool files delete <source> --includes ... --excludes ...

    public FilesDeleteCommand() : base("delete", "Delete files. Can be used to delete selected files.")
    {
        Option<bool> listOnlyOption = new Option<bool>(
            name: "--list",
            description: "List only. Defaults to true to lists files that would be deleted. Does not delete files! To delete files, use --list false (or -l false).",
            getDefaultValue: () => true
        );
        listOnlyOption.AddAlias("-l");

        Add(CommonArguments.SourcePathRequiredArgument);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);
        Add(listOnlyOption);

        this.SetHandler(async (source, includes, excludes, listOnly, verbose) =>
            {
                await Handle(source!, includes, excludes, listOnly, verbose);
            },
            CommonArguments.SourcePathRequiredArgument, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, listOnlyOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo source,
                        List<string> includes,
                        List<string> excludes,
                        bool listOnly,
                        bool verbose)
    {
        Directory.SetCurrentDirectory(source.FullName);

        Matcher matcher = new();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);
        

        if (verbose)
        {
            Console.WriteLine($"{(listOnly ? "Listing" : "Deleting")} file(s) from '{source.Name}'");
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            if (listOnly)
            {
                Console.WriteLine($"\n- list only enabled. No files will be deleted. Use --list false (or -l false) to delete files.");
            }
            Console.WriteLine();
        }

        var toBeDeleted = matcher.GetResultsInFullPath(source.FullName).ToList();
        if (listOnly)
        {
            Console.WriteLine($"Files that would be deleted:");
        }
        int counter = 0;
        foreach (string file in toBeDeleted)
        {
            string relativeFile = Path.GetRelativePath(source.FullName, file);
            FileInfo sourceFile = new(file);
            if (verbose && false == listOnly)
            {
                Console.WriteLine($"    {relativeFile}");
            }
            if (sourceFile.Exists)
            {
                if (listOnly)
                {
                    Console.WriteLine($"- {++counter:0000} file: {sourceFile.FullName}");
                }
                else
                {
                    sourceFile.Delete();
                }
            }
        }
    }
}
