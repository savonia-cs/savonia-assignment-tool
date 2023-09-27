using System.CommandLine;
using System.IO.Compression;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsUnpackCommand : Command
{
    public SubmissionsUnpackCommand() : base("unpack", "Unpack (unzip) all zip files in defined source folder. Creates a folder for each zip file where the contents are unpacked and overwrites possible existing files.")
    {
        var charactersToRemoveOption = new Option<List<string>?>(
            name: "--characters",
            description: "A list of characters to remove from unpacked folder names. Use single characters (i.e. , . -) or strings (i.e. ae ab) to remove occurrences of those in the created folder name.",
            getDefaultValue: () => new List<string> { "," })
        {
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourcePathArgument);
        Add(charactersToRemoveOption);

        this.SetHandler(async (path, charactersToRemove, verbose) =>
            {
                await Handle(path!, charactersToRemove, verbose);
            },
            CommonArguments.SourcePathArgument, charactersToRemoveOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path, List<string>? charactersToRemove, bool verbose)
    {

        var zipFiles = path.GetFiles().Where(f => f.Extension.Equals(".zip", StringComparison.InvariantCultureIgnoreCase));
        var zipFilesCount = zipFiles.Count();
        if (verbose)
        {
            Console.WriteLine($"Unpacking submissions from folder '{path.Name}'");
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
                try
                {
                    using (ZipArchive zipArchive = ZipFile.OpenRead(file.FullName))
                    {
                        if (verbose)
                        {
                            Console.WriteLine($"{counter++,4}: {file.Name}");
                        }
                        var folderName = file.Name.Replace(file.Extension, string.Empty);
                        if (charactersToRemove != null && charactersToRemove.Any())
                        {
                            foreach (var character in charactersToRemove)
                            {
                                folderName = folderName.Replace(character, string.Empty);
                            }
                        }
                        zipArchive.ExtractToDirectory(folderName, true);
                    }
                }
                catch (Exception ex)
                {
                    var cc = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"!{counter++,3}: FAILED to unpack file {file.Name}");
                    Console.ForegroundColor = cc;
                }
            }
        }
    }
}

