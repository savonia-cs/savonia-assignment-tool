using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class FilesCopyCommand : Command
{
    // savoniatool files copy <source> <destination> --includes ... --excludes ...

    public FilesCopyCommand() : base("copy", "Copy files and folders. Can be used to copy selected files and folder from a solution to a new location. Preserves folder structure.")
    {
        Argument<DirectoryInfo> destinationPathArgument = new Argument<DirectoryInfo>(
            name: "destinationPath",
            description: "Destination path where to copy the files and folders. If the path does not exist it will be created."
            );

        Add(CommonArguments.SourcePathArgument);
        Add(destinationPathArgument);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);

        this.SetHandler(async (source, destination, includes, excludes, verbose) =>
            {
                await Handle(source, destination, includes, excludes, verbose);
            },
            CommonArguments.SourcePathArgument, destinationPathArgument, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo source,
                        DirectoryInfo destination,
                        List<string> includes,
                        List<string> excludes,
                        bool verbose)
    {
        Directory.SetCurrentDirectory(source.FullName);

        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);

        if (verbose)
        {
            Console.WriteLine($"Copying files and folders from '{source.Name}' to '{destination.Name}'");
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            Console.WriteLine();
        }

        if (false == destination.Exists)
        {
            destination.Create();
        }

        var filesToCopy = matcher.GetResultsInFullPath(source.FullName).ToList();
        foreach (string file in filesToCopy)
        {
            string relativeFile = Path.GetRelativePath(source.FullName, file);
            FileInfo sourceFile = new FileInfo(file);
            string destinationFile = Path.Combine(destination.FullName, relativeFile);
            DirectoryInfo destinationPath = new DirectoryInfo(Path.GetDirectoryName(destinationFile)!);
            if (verbose)
            {
                Console.WriteLine($"    {relativeFile}");
            }
            if (false == destinationPath.Exists)
            {
                destinationPath.Create();
            }
            sourceFile.CopyTo(destinationFile, true);
        }
    }
}
