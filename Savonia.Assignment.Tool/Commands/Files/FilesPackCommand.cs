using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Files;

public class FilesPackCommand : Command
{
    // savoniatool files pack <sourcePath> <destinationZipFile> --includes ... --excludes ...

    public FilesPackCommand() : base("pack", "Pack selected files and folders to a zip package. Preserves folder structure.")
    {
        var destinationZipArgument = new Argument<string?>(
            name: "destinationZipFile",
            description: "Destination zip file. By default the zip file is named the same as the source folder name.",
            getDefaultValue: () => null);

        Add(CommonArguments.SourcePathArgument);
        Add(destinationZipArgument);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);

        this.SetHandler(async (source, output, includes, excludes, verbose) =>
        {
            await Handle(source!, output ?? $"{source.Name}.zip", includes, excludes, verbose);
        },
        CommonArguments.SourcePathArgument, destinationZipArgument, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path,
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

        Console.WriteLine($"Packing files from folder '{path.Name}'");
        Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
        Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
        Console.WriteLine();
        Console.WriteLine($"Result is packed to '{output}' file.");

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        using (ZipArchive zipArchive = ZipFile.Open(output, ZipArchiveMode.Create))
        {
            string runDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(path.FullName);
            foreach (string file in matcher.GetResultsInFullPath(path.FullName))
            {
                string relativeFile = Path.GetRelativePath(path.FullName, file);
                if (verbose)
                {
                    Console.WriteLine($"- adding file: {relativeFile}");
                }
                zipArchive.CreateEntryFromFile(relativeFile, relativeFile);
            }
            Directory.SetCurrentDirectory(runDir);
        }
    }
}
