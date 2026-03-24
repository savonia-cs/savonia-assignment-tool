using System.CommandLine;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Hash;

public class HashCreateCommand : Command
{
    public HashCreateCommand() : base("create", "Create comparable hashes of code files in defined folder.")
    {
        var csvOutputArgument = new Argument<string?>("hashesOutput")
        {
            Description = "Output csv file. This will overwrite possible existing file. By default the csv file is named the same as the source folder name with \"-hashes.csv\" appended to the end.",
            DefaultValueFactory = _ => null
        };

        // regex filters for code comments in C#, see https://stackoverflow.com/a/3524689
        var commentRegexFiltersOption = new Option<List<string>>("--regex-filters")
        {
            Description = "Regex filters to find code comments.",
            DefaultValueFactory = _ => new List<string> { @"/\*(.*?)\*/", @"//(.*?)\r?\n", @"""((\\[^\n]|[^""\n])*)""", @"@(""[^""]*"")+" },
            AllowMultipleArgumentsPerToken = true
        };

        var startingLineCommentOption = new Option<string>("--starting-line-comment")
        {
            Description = "Line comment start string",
            DefaultValueFactory = _ => "//"
        };

        var startingBlockCommentOption = new Option<string>("--starting-block-comment")
        {
            Description = "Block comment start string",
            DefaultValueFactory = _ => "/*"
        };

        var filterSourceCodeOption = new Option<SourceCodeFilters>("--filter-source-code")
        {
            Description = "Filter files before hashing.",
            DefaultValueFactory = _ => SourceCodeFilters.All
        };

        var folderHashOption = new Option<bool>("--folder-hash")
        {
            Description = "Combine selected files in folder to one hash.",
            DefaultValueFactory = _ => false
        };

        Add(CommonArguments.SourcePathArgument);
        Add(csvOutputArgument);
        Add(CommonOptions.IncludesOption);
        Add(CommonOptions.ExcludesOption);
        Add(commentRegexFiltersOption);
        Add(startingBlockCommentOption);
        Add(startingLineCommentOption);
        Add(filterSourceCodeOption);
        Add(folderHashOption);

        this.SetAction(async parseResult =>
            {
                var folder = parseResult.GetValue(CommonArguments.SourcePathArgument)!;
                var output = parseResult.GetValue(csvOutputArgument) ?? $"{folder.Name}-hashes.csv";
                await Handle(folder,
                                output,
                                parseResult.GetValue(CommonOptions.IncludesOption)!,
                                parseResult.GetValue(CommonOptions.ExcludesOption)!,
                                parseResult.GetValue(commentRegexFiltersOption)!,
                                parseResult.GetValue(startingBlockCommentOption)!,
                                parseResult.GetValue(startingLineCommentOption)!,
                                parseResult.GetValue(filterSourceCodeOption),
                                parseResult.GetValue(folderHashOption),
                                parseResult.GetValue(GlobalOptions.VerboseOption));
            });            
    }

    async Task Handle(DirectoryInfo path,
                        string output,
                        List<string> includes,
                        List<string> excludes,
                        List<string> commentRegex,
                        string startingBlockComment,
                        string startingLineComment,
                        SourceCodeFilters filterFiles,
                        bool folderHash,
                        bool verbose)
    {
        // if 'output' is written to 'path' then set it to excludes list
        string outputExclude = output.Replace(path.FullName, string.Empty);
        excludes.Add(outputExclude);

        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);

        if (folderHash)
        {
            Console.WriteLine($"Creating hashes for folders in '{path.Name}'");
        }
        else
        {
            Console.WriteLine($"Creating hashes for files from folders in '{path.Name}'");
        }
        Console.WriteLine();
        if (verbose)
        {
            Console.WriteLine($"- include pattern: {string.Join(" ", includes)}");
            Console.WriteLine($"- exclude pattern: {string.Join(" ", excludes)}");
            Console.WriteLine();
            if (filterFiles != SourceCodeFilters.None)
            {
                if (filterFiles.HasFlag(SourceCodeFilters.Comments))
                {
                    Console.WriteLine($"- filters comments from files with regex: {string.Join(" ", commentRegex)}");
                    Console.WriteLine($"- block comment start: {startingBlockComment}");
                    Console.WriteLine($"- line comment start: {startingLineComment}");
                }
                if (filterFiles.HasFlag(SourceCodeFilters.NewLines))
                {
                    Console.WriteLine($"- filters new lines");
                }
                if (filterFiles.HasFlag(SourceCodeFilters.WhiteSpaces))
                {
                    Console.WriteLine($"- filters white spaces");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine($"Result is saved to '{output}' file.");

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        Dictionary<string, Tuple<string, string>> fileHashes = new Dictionary<string, Tuple<string, string>>();
        var baseDirParts = path.DirectorySplit();
        foreach (string file in matcher.GetResultsInFullPath(path.FullName))
        {
            string relativeFile = Path.GetRelativePath(path.FullName, file);
            string key = new DirectoryInfo(file).DirectoryPart(baseDirParts, 0);

            if (verbose)
            {
                Console.WriteLine($"- hashing file: {relativeFile}");
            }
            var fileContent = await File.ReadAllTextAsync(file);
            if (filterFiles.HasFlag(SourceCodeFilters.Comments))
            {
                fileContent = FilterCommentsFromSourceFile(fileContent, commentRegex, startingBlockComment, startingLineComment);
            }
            if (filterFiles.HasFlag(SourceCodeFilters.NewLines))
            {
                fileContent = fileContent.Replace("\n", "").Replace("\r", "");
            }
            if (filterFiles.HasFlag(SourceCodeFilters.WhiteSpaces))
            {
                fileContent = fileContent.Replace(" ", "");
            }
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(fileContent)).ToBase64UrlEncoded();
            fileHashes.Add(relativeFile, new Tuple<string, string>(key, hash));
        }
        // StringBuilder resultBuilder = new StringBuilder();
        // resultBuilder.AppendLine($"\"{relativeFile}\",\"{hash}\"");
        using (var stream = File.OpenWrite(output))
        using (var writer = new StreamWriter(stream))
        {
            if (folderHash)
            {
                var folderHashes = fileHashes.Values.GroupBy(v => v.Item1);
                foreach (var fh in folderHashes)
                {
                    var folderFileHashes = fh.Select(f => f.Item2);
                    var folderFilesHash = SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("", folderFileHashes))).ToBase64UrlEncoded();                       
                    await writer.WriteLineAsync($"\"{fh.Key}\",\"{folderFilesHash}\"");
                }
            }
            else
            {
                foreach (var fileHash in fileHashes)
                {
                    await writer.WriteLineAsync($"\"{fileHash.Key}\",\"{fileHash.Value.Item2}\"");
                }
            }
        }
    }

    /// <summary>
    /// Filter out code comments.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="filters">Regex filters to match and filter out</param>
    /// <param name="startingBlockComment"></param>
    /// <param name="startingLineComment"></param>
    /// <returns></returns>
    internal string FilterCommentsFromSourceFile(string input, IEnumerable<string> filters, string startingBlockComment = "/*", string startingLineComment = "//")
    {
        string filtered = Regex.Replace(input, string.Join("|", filters),
            me =>
            {
                if (me.Value.StartsWith(startingBlockComment) || me.Value.StartsWith(startingLineComment))
                {
                    return me.Value.StartsWith(startingLineComment) ? Environment.NewLine : "";
                }
                // Keep the literal strings
                return me.Value;
            },
            RegexOptions.Singleline);
        return filtered;
    }       
}

[Flags]
public enum SourceCodeFilters
{
    None = 0,
    Comments = 1,
    WhiteSpaces = 2,
    NewLines = 4,
    All = Comments | WhiteSpaces | NewLines
}

