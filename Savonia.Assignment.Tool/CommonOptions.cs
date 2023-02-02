using System.CommandLine;

namespace Savonia.Assignment.Tool;

/// <summary>
/// Common options that are used by multiple commands. These needs to be added to the command via <see href="Command.Add()" /> method.
/// </summary>
public static class CommonOptions
{
    /// <summary>
    /// Patterns to exclude.
    /// Is empty by default.
    /// Allows multiple arguments per token.
    /// </summary>
    public static readonly Option<List<string>> ExcludesOption;
    /// <summary>
    /// Patterns to include. 
    /// Includes all files in all directories under the defined 'path' by default.
    /// Allows multiple arguments per token.
    /// </summary>
    public static readonly Option<List<string>> IncludesOption;
    /// <summary>
    /// Source csv file.
    /// </summary>
    public static readonly Option<FileInfo> SourceCsvFileOption;
    static CommonOptions()
    {
        ExcludesOption = new Option<List<string>>(
            name: "--excludes",
            description: "Folders and files to exclude.",
            getDefaultValue: () => new List<string> { })
            {
                AllowMultipleArgumentsPerToken = true
            };

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
        IncludesOption = new Option<List<string>>(
            name: "--includes",
            description: "Folders and files to include.",
            getDefaultValue: () => new List<string> { "**/*" })
            {
                AllowMultipleArgumentsPerToken = true
            };

        SourceCsvFileOption = new Option<FileInfo>(
            name: "--source",
            description: "Source csv file.",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    result.ErrorMessage = "Source csv file is not specified. Use --source option.";
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "File does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });
    }
}

