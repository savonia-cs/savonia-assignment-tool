using System;
using System.Reflection;
using System.IO.Compression;
using System.Collections.Concurrent;
using System.CommandLine;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Savonia.Assignment.Tool;

class Program
{
    // common usage:
    // savoniatool solution pack --output allsrc.zip --excludes test tests bin obj --includes **/*.cs 
    //
    // savoniatool answers test --result-file "moodle.csv" --path ./ --test-harness "path-to-folder-with-tests" --source-filters "**/src/my_code.cs" --test-runner python --test-runner-command "python testall.py" --test-points 1 1 1 1 1
    // dotnet test result line regex: .*?\b.*?\bFailed:.*?\b, Passed:.*?\b, Skipped:.*?\b, Total:.*?\b, Duration:.*?\b.dll.*?
    //
    // make hash of source code for duplicate checks:
    // 1. regex for clearing comments: https://stackoverflow.com/a/3524689
    // 2. remove spaces, \r, \n 
    // 3. create hash
    static async Task<int> Main(string[] args)
    {
        // path default is current working directory if no path is defined
        var sourcePathOption = new Option<DirectoryInfo?>(
            name: "--path",
            description: "Source path to operate on",
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

        // options and commands for solution handling
        var zipOutputOption = new Option<string>(
            name: "--output",
            description: "Output zip file. This will overwrite possible existing file.",
            getDefaultValue: () => "all.zip");
        zipOutputOption.AddAlias("-o");

        var excludesOption = new Option<List<string>>(
            name: "--excludes",
            description: "Folders and files to exclude.",
            getDefaultValue: () => new List<string> { });
        excludesOption.AllowMultipleArgumentsPerToken = true;

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
            description: "Folders and files to include.",
            getDefaultValue: () => new List<string> { "**/*" });
        includesOption.AllowMultipleArgumentsPerToken = true;

        var rootCommand = new RootCommand("Savonia tool for assingments");
        rootCommand.AddGlobalOption(sourcePathOption);

        var solutionCommand = new Command("solution", "Work with your solution to an assignment");
        rootCommand.AddCommand(solutionCommand);

        var packCommand = new Command("pack", "Pack your solution to a zip file.")
            {
                zipOutputOption,
                excludesOption,
                includesOption,
                verboseOption
            };
        solutionCommand.AddCommand(packCommand);

        packCommand.SetHandler(async (path, output, includes, excludes, verbose) =>
            {
                await PackSolution(path!, output, includes, excludes, verbose);
            },
            sourcePathOption, zipOutputOption, includesOption, excludesOption, verboseOption);


        // options and commands for returned solution zip files (answers) bulk handling
        var answersCommand = new Command("answers", "Work with multiple solutions sent as answers");
        rootCommand.AddCommand(answersCommand);

        var unpackCommand = new Command("unpack", "Unpack (unzip) all zip files in defined 'path'. Creates a folder for each zip file where the contents are unpacked and overwrites possible existing files.")
            {
                verboseOption
            };
        answersCommand.AddCommand(unpackCommand);

        unpackCommand.SetHandler(async (path, verbose) =>
            {
                await UnpackAnswers(path!, verbose);
            },
            sourcePathOption, verboseOption);

        // options and commands for hash operations to compare files
        var hashCommand = new Command("hash", "Create hashes from files and operate on them.");
        rootCommand.AddCommand(hashCommand);

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

        var filterSourceCodeOption = new Option<bool>(
            name: "--filter-source-code",
            description: "Filter files before hashing.",
            getDefaultValue: () => true);

        var createHashCommand = new Command("create", "Create comparable hashes of code files in defined 'path'.")
            {
                csvOutputOption,
                includesOption,
                excludesOption,
                commentRegexFiltersOption,
                startingBlockCommentOption,
                startingLineCommentOption,
                filterSourceCodeOption,
                verboseOption
            };
        hashCommand.AddCommand(createHashCommand);

        var hashIndexOption = new Option<int?>(
            name: "--hash-index",
            description: "Column index for the hash column. Null value assumes that hash is in the last column.",
            getDefaultValue: () => null);

        var sourceCsvFileOption = new Option<FileInfo>(
            name: "--source",
            description: "Source csv file.");

        var compareHashCommand = new Command("compare", "Compare hashes from source file.")
            {
                sourceCsvFileOption,
                csvOutputOption,
                hashIndexOption,
                verboseOption
            };
        hashCommand.AddCommand(compareHashCommand);

        var fileIndexOption = new Option<int?>(
            name: "--file-index",
            description: "Column index for the file column. Null value assumes that file is in the first column.",
            getDefaultValue: () => null);

        var editorOption = new Option<string>(
            name: "--editor",
            description: "Editor executable name. The executable should be in the PATH.",
            getDefaultValue: () => "code");

        var editorParamsOption = new Option<string>(
            name: "--editor-params",
            description: "Parameters for the editor executable.",
            getDefaultValue: () => "-n");

        var openHashCommand = new Command("open", "Open match groups with defined editor.")
            {
                sourceCsvFileOption,
                hashIndexOption,
                fileIndexOption,
                editorOption,
                editorParamsOption,
                verboseOption
            };
        hashCommand.AddCommand(openHashCommand);


        createHashCommand.SetHandler(async (context) =>
            {
                await CreateHash(context.ParseResult.GetValueForOption(sourcePathOption)!,
                                 context.ParseResult.GetValueForOption(csvOutputOption)!,
                                 context.ParseResult.GetValueForOption(includesOption)!,
                                 context.ParseResult.GetValueForOption(excludesOption)!,
                                 context.ParseResult.GetValueForOption(commentRegexFiltersOption)!,
                                 context.ParseResult.GetValueForOption(startingBlockCommentOption)!,
                                 context.ParseResult.GetValueForOption(startingLineCommentOption)!,
                                 context.ParseResult.GetValueForOption(filterSourceCodeOption),
                                 context.ParseResult.GetValueForOption(verboseOption));
            });

        compareHashCommand.SetHandler(async (file, output, hashIndex, verbose) =>
            {
                await CompareHashes(file!, output, hashIndex, verbose);
            },
            sourceCsvFileOption, csvOutputOption, hashIndexOption, verboseOption);

        openHashCommand.SetHandler(async (file, hashIndex, fileIndex, editor, editorParams, verbose) =>
            {
                await OpenHashes(file!, hashIndex, fileIndex, editor, editorParams, verbose);
            },
            sourceCsvFileOption, hashIndexOption, fileIndexOption, editorOption, editorParamsOption, verboseOption);

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

    internal static async Task UnpackAnswers(DirectoryInfo path,
                                            bool verbose)
    {

        var zipFiles = path.GetFiles().Where(f => f.Extension.Equals(".zip", StringComparison.InvariantCultureIgnoreCase));
        var zipFilesCount = zipFiles.Count();
        if (verbose)
        {
            Console.WriteLine($"Unpacking answers from folder '{path.Name}'");
            Console.WriteLine($"- contains {zipFilesCount} .zip files");
        }
        if (zipFilesCount > 0)
        {
            int counter = 1;
            if (verbose)
            {
                Console.WriteLine($"- unpacking files:");
            }
            foreach (var file in zipFiles)
            {
                using (ZipArchive zipArchive = ZipFile.OpenRead(file.FullName))
                {
                    if (verbose)
                    {
                        Console.WriteLine($"{counter++,4}: {file.Name}");
                    }
                    zipArchive.ExtractToDirectory(file.FullName.Replace(file.Extension, ""), true);
                }
            }
        }
    }

    internal static async Task CreateHash(DirectoryInfo path,
                                            string output,
                                            List<string> includes,
                                            List<string> excludes,
                                            List<string> commentRegex,
                                            string startingBlockComment,
                                            string startingLineComment,
                                            bool filterFiles,
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
            if (filterFiles)
            {
                Console.WriteLine($"- filters files with regex: {string.Join(" ", commentRegex)}");
                Console.WriteLine($"- block comment start: {startingBlockComment}");
                Console.WriteLine($"- line comment start: {startingLineComment}");
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
            if (filterFiles)
            {
                fileContent = FilterCommentsFromSourceFile(fileContent, commentRegex, startingBlockComment, startingLineComment);
                fileContent = Condense(fileContent);
            }
            var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(fileContent)));

            resultBuilder.AppendLine($"\"{relativeFile}\",\"{hash}\"");
        }
        await File.WriteAllTextAsync(output, resultBuilder.ToString());
    }

    internal static async Task CompareHashes(FileInfo file, string output, int? hashIndex, bool verbose)
    {
        // if hashIndex == null -> assume that hash value is in the last column

        if (false == file.Exists)
        {
            Console.WriteLine($"Source file \"{file.FullName}\" does not exist.");
            return;
        }
        if (verbose)
        {
            Console.WriteLine($"Reading hashes from source \"{file.Name}\"");
        }
        List<List<string>> data = await ReadCsvFile(file);
        if (null == hashIndex && data.Any())
        {
            // assume that hash value is in the last column
            hashIndex = data.First().Count() - 1;
        }
        var grouped = data.GroupBy(d => d[hashIndex.Value]);
        // list only those with same hashes
        var sameHashes = grouped.Where(g => g.Count() > 1);
        var cc = Console.ForegroundColor;
        if (sameHashes.Count() > 0)
        {
            using (var sw = File.CreateText(output))
            {
                foreach (var group in sameHashes)
                {
                    if (verbose)
                    {
                        Console.WriteLine($"- {group.Key}");
                    }
                    int counter = 1;
                    foreach (var item in group)
                    {
                        string line = string.Join(",", item.Select(i => $"\"{i}\""));
                        if (verbose)
                        {
                            Console.WriteLine($"{counter++,4}: {line}");
                        }
                        await sw.WriteLineAsync(line);
                    }
                    await sw.WriteLineAsync();
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"COLLISIONS! File \"{file.Name}\" contains {sameHashes.Count()} collisions.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File \"{file.Name}\" did not contain collisions.");
        }
        Console.ForegroundColor = cc;
    }

    internal static async Task OpenHashes(FileInfo file, int? hashIndex, int? fileIndex, string editor, string editorParams, bool verbose)
    {
        if (false == file.Exists)
        {
            Console.WriteLine($"Source file \"{file.FullName}\" does not exist.");
            return;
        }
        if (verbose)
        {
            Console.WriteLine($"Opening hash groups from source \"{file.Name}\" with editor \"{editor}\"");
        }
        List<List<string>> data = await ReadCsvFile(file);
        if (null == hashIndex && data.Any())
        {
            // assume that hash value is in the last column
            hashIndex = data.First().Count() - 1;
        }
        // if fileIndex == null -> assume that file is in the first column
        fileIndex = fileIndex ?? 0;

        var grouped = data.GroupBy(d => d[hashIndex.Value]);
        var sameHashes = grouped.Where(g => g.Count() > 1);
        if (sameHashes.Count() > 0)
        {
            foreach (var group in sameHashes)
            {
                string filesToOpen = string.Join(" ", group.Select(line => $"\"{line[fileIndex.Value]}\""));

                if (verbose)
                {
                    Console.WriteLine($"- {group.Key}");
                    Console.WriteLine($"  {editor} {editorParams} {string.Join(" ", filesToOpen)}");
                }
            
                ProcessStartInfo psi = new ProcessStartInfo(editor, $"{editorParams} {string.Join(" ", filesToOpen)}");
                psi.UseShellExecute = true;
                psi.CreateNoWindow = true;
                Process.Start(psi);
            }
        }
        else
        {
            Console.WriteLine($"File \"{file.Name}\" did not contain collisions. Nothing to open.");
        }
    }

    internal static async Task<List<List<string>>> ReadCsvFile(FileInfo file)
    {
        List<List<string>> data = new List<List<string>>();
        using (var fs = file.OpenRead())
        using (StreamReader sr = new StreamReader(fs))
        {
            string content = await sr.ReadToEndAsync();
            content = content.Replace("\r", "");
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(','); // TODO: handle cases where columns content contains comma (,)
                data.Add(columns.Select(c => c.Trim('"')).ToList());
            }
        }
        return data;
    }

    /// <summary>
    /// Filter out code comments.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="filters">Regex filters to match and filter out</param>
    /// <param name="startingBlockComment"></param>
    /// <param name="startingLineComment"></param>
    /// <returns></returns>
    internal static string FilterCommentsFromSourceFile(string input, IEnumerable<string> filters, string startingBlockComment = "/*", string startingLineComment = "//")
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

    /// <summary>
    /// Filter out new lines, carriage returns and white spaces
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    internal static string Condense(string input)
    {
        return input.Replace(" ", "", StringComparison.InvariantCultureIgnoreCase).Replace("\n", "", StringComparison.InvariantCultureIgnoreCase).Replace("\r", "", StringComparison.InvariantCultureIgnoreCase);
    }
}

