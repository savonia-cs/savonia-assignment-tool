using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands.Files;

public class FilesUnpackCommand : Command
{
    // savoniatool files unpack <source-zip-file> <destination>

    public FilesUnpackCommand() : base("unpack", "Unpack files and folders from a zip package. Preserves folder structure.")
    {
        var sourceArgument = new Argument<FileInfo>("sourceZipFile")
        {
            Description = "Source zip file to unpack"
        };

        sourceArgument.Validators.Add(result =>
        {
            var file = result.GetValue(sourceArgument).FullName ?? string.Empty;
            if (false == File.Exists(file))
            {
                result.AddError($"Source file '{file}' does not exist");
            }
        });

        var destinationPathArgument = new Argument<string?>("destinationPath")
        {
            Description = "Destination path to unpack the zip file. Default value is the zip file name without extension in current folder.",
            DefaultValueFactory = _ => null
        };

        Add(sourceArgument);
        Add(destinationPathArgument);

        this.SetAction(async (parseResult) =>
        {
            await Handle(parseResult.GetValue(sourceArgument)!,
                            parseResult.GetValue(destinationPathArgument) ?? Path.GetFileNameWithoutExtension(parseResult.GetValue(sourceArgument)!.Name),
                            parseResult.GetValue(GlobalOptions.VerboseOption));
        });
    }

    async Task Handle(FileInfo source,
                        string output,
                        bool verbose)
    {
        Directory.SetCurrentDirectory(source.DirectoryName ?? "./");
        Console.WriteLine($"Unpacking '{source.Name}' to {output}");
        try
        {
            using (ZipArchive zipArchive = ZipFile.OpenRead(source.FullName))
            {
                zipArchive.ExtractToDirectory(output, true);
            }
        }
        catch (Exception ex)
        {
            var cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!FAILED to unpack file {source.Name}");
            Console.ForegroundColor = cc;
        }
    }
}
