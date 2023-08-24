using System.CommandLine;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class HashCreateCommand : Command
{
    public HashCreateCommand() : base("create", "Create comparable hashes of code files in defined folder.")
    {
        var csvOutputArgument = new Argument<string?>(
            name: "hashesOutput",
            description: "Output csv file. This will overwrite possible existing file. By default the csv file is named the same as the source folder name with \"-hashes.csv\" appended to the end.",
            getDefaultValue: () => null);

        // regex filters for code comments in C#, see https://stackoverflow.com/a/3524689
        var commentRegexFiltersOption = new Option<List<string>>(
            name: "--regex-filters",
            description: "Regex filters to find code comments.",
            getDefaultValue: () => new List<string> { @"/\*(.*?)\*/", @"//(.*?)\r?\n", @"""((\\[^\n]|[^""\n])*)""", @"@(""[^""]*"")+" });
        commentRegexFiltersOption.AllowMultipleArgumentsPerToken = true;

        var startingLineCommentOption = new Option<string>(
            name: "--starting-line-comment",
            description: "Line comment start string",
            getDefaultValue: () => "//");

        var startingBlockCommentOption = new Option<string>(
            name: "--starting-block-comment",
            description: "Block comment start string",
            getDefaultValue: () => "/*");

        var filterSourceCodeOption = new Option<SourceCodeFilters>(
            name: "--filter-source-code",
            description: "Filter files before hashing.",
            getDefaultValue: () => SourceCodeFilters.All);

        var folderHashOption = new Option<bool>(
            name: "--folder-hash",
            description: "Combine selected files in folder to one hash.",
            getDefaultValue: () => false);

        Add(CommonArguments.SourcePathArgument);
        Add(csvOutputArgument);
        Add(CommonOptions.IncludesOption);
        Add(CommonOptions.ExcludesOption);
        Add(commentRegexFiltersOption);
        Add(startingBlockCommentOption);
        Add(startingLineCommentOption);
        Add(filterSourceCodeOption);
        Add(folderHashOption);

        this.SetHandler(async (context) =>
            {
                var folder = context.ParseResult.GetValueForArgument(CommonArguments.SourcePathArgument)!;
                var output = context.ParseResult.GetValueForArgument(csvOutputArgument) ?? $"{folder.Name}-hashes.csv";
                await Handle(folder,
                                output,
                                context.ParseResult.GetValueForOption(CommonOptions.IncludesOption)!,
                                context.ParseResult.GetValueForOption(CommonOptions.ExcludesOption)!,
                                context.ParseResult.GetValueForOption(commentRegexFiltersOption)!,
                                context.ParseResult.GetValueForOption(startingBlockCommentOption)!,
                                context.ParseResult.GetValueForOption(startingLineCommentOption)!,
                                context.ParseResult.GetValueForOption(filterSourceCodeOption),
                                context.ParseResult.GetValueForOption(folderHashOption),
                                context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
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

