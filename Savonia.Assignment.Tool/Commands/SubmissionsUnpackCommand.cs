﻿using System.CommandLine;
using System.IO.Compression;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsUnpackCommand : Command
{
    public SubmissionsUnpackCommand() : base("unpack", "Unpack (unzip) all zip files in defined source folder. Creates a folder for each zip file where the contents are unpacked and overwrites possible existing files.")
    {
        Add(CommonArguments.SourcePathArgument);

        this.SetHandler(async (path, verbose) =>
            {
                await Handle(path!, verbose);
            },
            CommonArguments.SourcePathArgument, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path,
                                        bool verbose)
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
                        zipArchive.ExtractToDirectory(file.FullName.Replace(file.Extension, ""), true);
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

