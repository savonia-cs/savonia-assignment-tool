using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsPackCommand : Command
{
    public SubmissionsPackCommand() : base("pack", "Pack (zip) all submission folders to zip files in defined source folder. Creates a zip file for each folder and packs the content of the folder excluding the folder itself. Uses the folder name as the name of the zip file and overwrites possible existing file.")
    {
        var zipOutputOption = new Option<string?>(
        name: "--output",
        description: "Output zip file. When defined the included result is packed to a single zip file. Can be used to pack all submission zip files to a single zip file. This will overwrite possible existing file.",
        getDefaultValue: () => null);
        zipOutputOption.AddAlias("-o");

        Add(CommonArguments.SourcePathArgument);
        AddOption(zipOutputOption);
        AddOption(CommonOptions.IncludesOption);
        AddOption(CommonOptions.ExcludesOption);
        this.SetHandler(async (path, includes, excludes, output, verbose) =>
            {
                await Handle(path!, includes, excludes, output, verbose);
            },
            CommonArguments.SourcePathArgument, CommonOptions.IncludesOption, CommonOptions.ExcludesOption, zipOutputOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path, List<string> includes, List<string> excludes, string? output, bool verbose)
    {
        bool isOutputDefined = false == string.IsNullOrWhiteSpace(output);
        if (null == excludes)
        {
            excludes = new List<string>();
        }
        if (false == isOutputDefined)
        {
            // when excludes is not set then exclude *.zip files from path directory when not creating a single zip file
            // zip files in sub directories are included
            if (excludes.Count == 0)
            {
                excludes = new List<string>() { $"*.zip" };
            }
        }
        else
        {
            // when creating a single zip file and the default globing pattern (**/*) for includes is used
            // then use *.zip as the includes pattern to pack only zip files in path directory
            // and also exclude the output file
            string outputExclude = output!.Replace(path.FullName, string.Empty);
            excludes.Add(outputExclude);

            if (includes.Count == 1 && includes[0] == "**/*")
            {
                includes[0] = "*.zip";
            }
        }


        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);


        if (verbose)
        {
            Console.WriteLine($"Packing submissions from folder '{path.Name}'");
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            Console.WriteLine();
            if (isOutputDefined)
            {
                Console.WriteLine($"Result is packed to '{output}' file.");
            }
            else
            {
                Console.WriteLine($"Each subfolder from resulting set in folder '{path.Name}' is packed to its own zip file.");
            }
        }

        // set working directory to path
        Directory.SetCurrentDirectory(path.FullName);

        var resultingSet = matcher.GetResultsInFullPath(path.FullName);
        if (isOutputDefined)
        {
            PackToSingleFile(path, output!, verbose, resultingSet);
        }
        else
        {
            PackToSubdirectoryFiles(path, verbose, resultingSet);
        }
    }

    private void PackToSubdirectoryFiles(DirectoryInfo path, bool verbose, IEnumerable<string> resultingSet)
    {
        // group results by subfolder name
        var pathParts = path.DirectorySplit();

        var groupedResults = resultingSet.GroupBy(x => new DirectoryInfo(Path.GetDirectoryName(x)).DirectoryPart(pathParts, 0));
        if (verbose)
        {
            Console.WriteLine($"Packing {groupedResults.Count()} result(s) to individual zip files");
        }
        int counter = 1;
        foreach (var group in groupedResults)
        {
            string zipFileName = $"{group.Key}.zip";
            if (verbose)
            {
                Console.WriteLine($"{counter++,4} pack {group.Key} to {zipFileName}");
            }
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            using (ZipArchive zipArchive = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                foreach (string file in group)
                {
                    string relativeFile = Path.GetRelativePath(path.FullName, file);
                    string relativeFileName = Path.GetRelativePath(Path.Combine(path.FullName, group.Key), relativeFile);
                    if (verbose)
                    {
                        Console.WriteLine($"{"-", 6} adding file: {relativeFileName}");
                    }
                    zipArchive.CreateEntryFromFile(relativeFile, relativeFileName);
                }
            }
        }
    }

    private void PackToSingleFile(DirectoryInfo path, string output, bool verbose, IEnumerable<string> resultingSet)
    {
        // pack globing results to single zip file
        if (File.Exists(output))
        {
            File.Delete(output);
        }
        if (verbose)
        {
            Console.WriteLine($"Packing results to file: {output}");
        }
        int counter = 1;
        using (ZipArchive zipArchive = ZipFile.Open(output, ZipArchiveMode.Create))
        {
            foreach (string file in resultingSet)
            {
                string relativeFile = Path.GetRelativePath(path.FullName, file);
                if (verbose)
                {
                    Console.WriteLine($"{counter++,4} adding file: {relativeFile}");
                }
                zipArchive.CreateEntryFromFile(relativeFile, relativeFile);
            }
        }
    }
}

