using System.CommandLine;
using System.IO.Compression;

namespace Savonia.Assignment.Tool.Commands;

public class AnswersUnpackCommand : Command
{
    public AnswersUnpackCommand() : base("unpack", "Unpack (unzip) all zip files in defined 'path'. Creates a folder for each zip file where the contents are unpacked and overwrites possible existing files.")
    {
        this.SetHandler(async (path, verbose) =>
            {
                await Handle(path!, verbose);
            },
            GlobalOptions.SourcePathOption, GlobalOptions.VerboseOption);
    }

        internal static async Task Handle(DirectoryInfo path,
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
}

