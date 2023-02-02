using System.CommandLine;

namespace Savonia.Assignment.Tool;

public static class GlobalOptions
{
    public static readonly Option<DirectoryInfo?> SourcePathOption;
    public static readonly Option<bool> VerboseOption;
    public static readonly Option<List<string>> ExcludesOption;
    public static readonly Option<List<string>> IncludesOption;
    static GlobalOptions()
    {
        // path default is current working directory if no path is defined
        SourcePathOption = new Option<DirectoryInfo?>(
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

        VerboseOption = new Option<bool>(
            name: "--verbose",
            description: "Show verbose output.",
            getDefaultValue: () => false);
        VerboseOption.AddAlias("-v");

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
    }
}

