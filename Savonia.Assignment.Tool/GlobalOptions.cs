using System.CommandLine;

namespace Savonia.Assignment.Tool;

/// <summary>
/// Global options contains <see href="Option<T>" />s that are set as global options. 
/// These can be used on commands but they do not need to be added to the command via <see href="Command.Add()" /> method.
/// </summary>
public static class GlobalOptions
{
    /// <summary>
    /// Verbose option. Set true to enable verbose messages.
    /// Default is false.
    /// </summary>
    public static readonly Option<bool> VerboseOption;
    static GlobalOptions()
    {
        VerboseOption = new Option<bool>(
            name: "--verbose",
            description: "Show verbose output.",
            getDefaultValue: () => false);
        VerboseOption.AddAlias("-v");
    }
}

