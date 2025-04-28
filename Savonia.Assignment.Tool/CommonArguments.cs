using System.CommandLine;

namespace Savonia.Assignment.Tool;

/// <summary>
/// Common options that are used by multiple commands. These needs to be added to the command via <see href="Command.Add()" /> method.
/// </summary>
public static class CommonArguments
{
    /// <summary>
    /// Source csv file.
    /// </summary>
    public static readonly Argument<FileInfo?> SourceCsvFileArgument;

    /// <summary>
    /// Source path to operate on. Defaults to current working directory if no path is defined.
    /// </summary>
    public static readonly Argument<DirectoryInfo> SourcePathArgument;

    /// <summary>
    /// Source path to operate on. Defaults to empty if no path is defined (i.e. a value must be provided).
    /// </summary>
    public static readonly Argument<DirectoryInfo?> SourcePathRequiredArgument;
    static CommonArguments()
    {
        SourceCsvFileArgument = new Argument<FileInfo?>(
            name: "sourceFile",
            description: "Source CSV file.",
            parse: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    result.ErrorMessage = "Source CSV file is not specified.";
                    return null;
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "Source CSV file does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });

        // path default is current working directory if no path is defined
        SourcePathArgument = new Argument<DirectoryInfo>(
            name: "sourcePath",
            description: "Source path to operate on",
            getDefaultValue: () => new DirectoryInfo(Directory.GetCurrentDirectory()));

        SourcePathArgument.AddValidator(result =>
        {
            var path = result.GetValueForArgument(SourcePathArgument).FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.ErrorMessage = $"Source path '{path}' does not exist";
            }
        });
                        
        // path default is current working directory if no path is defined
        SourcePathRequiredArgument = new Argument<DirectoryInfo?>(
            name: "sourcePath",
            description: "Source path to operate on",
            getDefaultValue: () => null);

        SourcePathRequiredArgument.AddValidator(result =>
        {
            if (result.Tokens.Count == 0)
            {
                result.ErrorMessage = "Source path is not specified.";
                return;
            }
            else
            {
                var path = result.GetValueForArgument(SourcePathRequiredArgument).FullName ?? string.Empty;
                if (false == Directory.Exists(path))
                {
                    result.ErrorMessage = $"Source path '{path}' does not exist";
                }
            }
        });

    }
}

