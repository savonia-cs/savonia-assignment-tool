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
        SourceCsvFileArgument = new Argument<FileInfo?>("sourceFile")
        {
            Description = "Source CSV file.",
        };
        SourceCsvFileArgument.Validators.Add(result =>
        {
            if (result.Tokens.Count == 0)
            {
                result.AddError("Source CSV file is not specified.");
                return;
            }
            string? filePath = result.GetValueOrDefault<FileInfo?>()?.FullName;
            if (string.IsNullOrEmpty(filePath) || false == File.Exists(filePath))
            {
                result.AddError($"Source CSV file '{filePath}' does not exist");
            }
        });
            

        // path default is current working directory if no path is defined
        SourcePathArgument = new Argument<DirectoryInfo>("sourcePath")
        {
            Description = "Source path to operate on",
            DefaultValueFactory = _ => new DirectoryInfo(Directory.GetCurrentDirectory())
        };

        SourcePathArgument.Validators.Add(result =>
        {
            var path = result.GetValueOrDefault<DirectoryInfo>()?.FullName ?? string.Empty;
            if (false == Directory.Exists(path))
            {
                result.AddError($"Source path '{path}' does not exist");
            }
        });
                        
        // path default is current working directory if no path is defined
        SourcePathRequiredArgument = new Argument<DirectoryInfo?>("sourcePath")
        {
            Description = "Source path to operate on",
            DefaultValueFactory = _ => null
        };

        SourcePathRequiredArgument.Validators.Add(result =>
        {
            if (result.Tokens.Count == 0)
            {
                result.AddError("Source path is not specified.");
                return;
            }
            else
            {
                var path = result.GetValueOrDefault<DirectoryInfo?>()?.FullName ?? string.Empty;
                if (false == Directory.Exists(path))
                {
                    result.AddError($"Source path '{path}' does not exist");
                }
            }
        });

    }
}

