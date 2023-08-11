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
    /// Source path to operate on.
    /// </summary>
    public static readonly Argument<DirectoryInfo> SourcePathArgument;
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
                        
    }
}

