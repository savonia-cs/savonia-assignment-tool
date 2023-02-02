using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;



public class SolutionPackCommand : Command
{
    public SolutionPackCommand() : base("pack", "Pack your solution to a zip file.")
    {
        var zipOutputOption = new Option<string>(
            name: "--output",
            description: "Output zip file. This will overwrite possible existing file.",
            getDefaultValue: () => "all.zip");
        zipOutputOption.AddAlias("-o");

        Add(zipOutputOption);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);

        this.SetHandler(async (path, output, includes, excludes, verbose) =>
        {
            await Handle(path!, output, includes, excludes, verbose);
        },
        GlobalOptions.SourcePathOption, zipOutputOption, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, GlobalOptions.VerboseOption);
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

