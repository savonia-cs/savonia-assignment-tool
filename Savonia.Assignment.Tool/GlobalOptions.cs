using System.CommandLine;

namespace Savonia.Assignment.Tool;

/// <summary>
/// Global options contains <see href="Option<T>" />s that are set as global options. 
/// These can be used on commands but they do not need to be added to the command via <see href="Command.Add()" /> method.
/// </summary>
public static class GlobalOptions
{
    /// <summary>
    /// Source path to operate on. 
    /// Is the current path (./) by default.
    /// </summary>
    public static readonly Option<DirectoryInfo?> SourcePathOption;
    /// <summary>
    /// Verbose option. Set true to enable verbose messages.
    /// Default is false.
    /// </summary>
    public static readonly Option<bool> VerboseOption;
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
    }
}

