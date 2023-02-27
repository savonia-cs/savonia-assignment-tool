using System.CommandLine;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class HashCreateCommand : Command
{
    public HashCreateCommand() : base("create", "Create comparable hashes of code files in defined 'path'.")
    {
        var csvOutputOption = new Option<string>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file.",
            getDefaultValue: () => "result.csv");
        csvOutputOption.AddAlias("-o");

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

        Add(csvOutputOption);
        Add(CommonOptions.IncludesOption);
        Add(CommonOptions.ExcludesOption);
        Add(commentRegexFiltersOption);
        Add(startingBlockCommentOption);
        Add(startingLineCommentOption);
        Add(filterSourceCodeOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForOption(GlobalOptions.SourcePathOption)!,
                                 context.ParseResult.GetValueForOption(csvOutputOption)!,
                                 context.ParseResult.GetValueForOption(CommonOptions.IncludesOption)!,
                                 context.ParseResult.GetValueForOption(CommonOptions.ExcludesOption)!,
                                 context.ParseResult.GetValueForOption(commentRegexFiltersOption)!,
                                 context.ParseResult.GetValueForOption(startingBlockCommentOption)!,
                                 context.ParseResult.GetValueForOption(startingLineCommentOption)!,
                                 context.ParseResult.GetValueForOption(filterSourceCodeOption),
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
                        // bool filterFiles,
                        SourceCodeFilters filterFiles,
                        bool verbose)
    {
        // if 'output' is written to 'path' then set it to excludes list
        string outputExclude = output.Replace(path.FullName, string.Empty);
        excludes.Add(outputExclude);

        Matcher matcher = new Matcher();
        matcher.AddIncludePatterns(includes);
        matcher.AddExcludePatterns(excludes);

        if (verbose)
        {
            Console.WriteLine($"Creating hashes from folder '{path.Name}'");
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
            Console.WriteLine($"Result is saved to '{output}' file.");
        }

        if (File.Exists(output))
        {
            File.Delete(output);
        }

        StringBuilder resultBuilder = new StringBuilder();
        foreach (string file in matcher.GetResultsInFullPath(path.FullName))
        {
            string relativeFile = file.Replace(path.FullName, "");

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
            var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(fileContent)));

            resultBuilder.AppendLine($"\"{relativeFile}\",\"{hash}\"");
        }
        await File.WriteAllTextAsync(output, resultBuilder.ToString());
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

