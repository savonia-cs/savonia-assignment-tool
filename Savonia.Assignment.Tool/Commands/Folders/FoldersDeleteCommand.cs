using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Folders;

public class FoldersDeleteCommand : Command
{
    // savoniatool files delete <source> --includes ... --excludes ...

    public FoldersDeleteCommand() : base("delete", "Delete folders. Can be used to delete selected folders. Note that this command matches folders by their files. If a folder contains files that match the include/exclude patterns, the folder will be deleted. If a folder does not contain any files that match the include/exclude patterns, the folder will not be deleted.")
    {
        Option<bool> listOnlyOption = new Option<bool>(
            name: "--list",
            description: "List only. Defaults to true to list folders that would be deleted. Does not delete folders! To delete folders, use --list false (or -l false).",
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
            Console.WriteLine($"{(listOnly ? "Listing" : "Deleting")} folder(s) from '{source.Name}'");
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            if (listOnly)
            {
                Console.WriteLine($"\n- list only enabled. No folders will be deleted. Use --list false (or -l false) to delete folders.");
            }
            Console.WriteLine();
        }

        var toBeDeleted = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(source.FullName)));
        if (listOnly)
        {
            Console.WriteLine($"Folders that would be deleted:");
        }
        int counter = 0;
        DirectoryInfo? lastDeletedDirectory = null;
        foreach (var file in toBeDeleted.Files)
        {
            FileInfo fileInfo = new(file.Path);
            if (false == fileInfo.Exists)
            {
                continue;
            }
            DirectoryInfo? parentDirectory = fileInfo.Directory;
            if (parentDirectory == null)
            {
                continue;
            }
            if (lastDeletedDirectory is not null && parentDirectory.FullName.StartsWith(lastDeletedDirectory.FullName))
            {
                continue;
            }
            if (verbose && false == listOnly)
            {
                Console.WriteLine($"    {parentDirectory.FullName}");
            }
            if (parentDirectory.Exists)
            {
                lastDeletedDirectory = parentDirectory;
                if (listOnly)
                {
                    Console.WriteLine($"- {++counter:0000} folder: {parentDirectory.FullName}");
                }
                else
                {
                    parentDirectory.Delete(true);
                }
            }
        }
    }
}
