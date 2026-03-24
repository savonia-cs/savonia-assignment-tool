using System.CommandLine;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Markdown2Pdf;
using Markdown2Pdf.Options;
using Savonia.Assignment.Tool.Models;

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsTestConvertCommand : Command
{
    // savoniatool submissions test convert <sourcePath> <destination> --title "title for the md file" --selected-submissions 1-10 --test-summary-file testrunsummary.json --md-file-prefix teema1_ --md-file-regex "(?<=_)[0-9]+(?=_)" --md-file-suffix

    private const string MD_FILE_EXTENSION = ".md";

    public SubmissionsTestConvertCommand() : base("convert", "Convert test run summaries in submission folders to md files.")
    {
        var destinationPathArgument = new Argument<string?>("destinationPath")
        {
            Description = "Destination path where to save to md files. Default value is the folder where the test run summary file is read.",
            DefaultValueFactory = _ => null
        };

        var titleOption = new Option<string?>("--title")
        {
            Description = "Title for the md file.",
            DefaultValueFactory = _ => "Test run summary"
        };
        var testSummaryFileOption = new Option<string>("--test-summary-file")
        {
            Description = "Test summary file name to read each submission's test run summary from.",
            DefaultValueFactory = _ => "testrunsummary.json"
        };

        var selectedSubmissionsOption = new Option<List<string>?>("--selected-submissions")
        {
            Description = "Set index number of submission folders to include in summary. Use 'submissions list' command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            DefaultValueFactory = _ => [],
            AllowMultipleArgumentsPerToken = true
        };

        var mdPrefixOption = new Option<string?>("--md-file-prefix")
        {
            Description = "A prefix text to append to the created md file name.",
            DefaultValueFactory = _ => null
        };

        var mdRegexOption = new Option<string?>("--md-file-regex")
        {
            Description = "A regex to get student identifier from submission folder name.",
            DefaultValueFactory = _ => "(?<=_)[0-9]+(?=_)"
        };

        var mdSuffixOption = new Option<string?>("--md-file-suffix")
        {
            Description = "A suffix text to append to the created md file name.",
            DefaultValueFactory = _ => null
        };

        var mdCreatePdfOption = new Option<bool>("--md-create-pdf")
        {
            Description = "Create also a PDF file from created markdown content.",
            DefaultValueFactory = _ => false
        };

        var mdCreatePdfKeepHtmlOption = new Option<bool>("--md-create-pdf-keep-html")
        {
            Description = "When creating PDF files, keep the HTML file.",
            DefaultValueFactory = _ => false
        };


        Add(CommonArguments.SourcePathArgument);
        Add(destinationPathArgument);
        Add(titleOption);
        Add(testSummaryFileOption);
        Add(selectedSubmissionsOption);
        Add(mdPrefixOption);
        Add(mdRegexOption);
        Add(mdSuffixOption);
        Add(mdCreatePdfOption);
        Add(mdCreatePdfKeepHtmlOption);

        this.SetAction(async parseResult =>
            {
                await Handle(parseResult.GetValue(CommonArguments.SourcePathArgument)!,
                                parseResult.GetValue(destinationPathArgument),
                                parseResult.GetValue(titleOption)!,
                                parseResult.GetValue(testSummaryFileOption)!,
                                parseResult.GetValue(selectedSubmissionsOption),
                                parseResult.GetValue(mdPrefixOption),
                                parseResult.GetValue(mdRegexOption),
                                parseResult.GetValue(mdSuffixOption),
                                parseResult.GetValue(mdCreatePdfOption),
                                parseResult.GetValue(mdCreatePdfKeepHtmlOption),
                                parseResult.GetValue(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(DirectoryInfo path,
                        string? destinationPath,
                        string title,
                        string submissionSummaryFile,
                        List<string>? selectedSubmissions,
                        string? mdPrefix,
                        string? mdRegex,
                        string? mdSuffix,
                        bool createPdf,
                        bool createPdfKeepHtml,
                        bool verbose)
    {
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);
        // create result summary file
        Console.WriteLine($"Converting summary files '{submissionSummaryFile}' from submissions in '{path.Name}' to md files with title {title}.");
        if (createPdf)
        {
            var ccolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string stars = new string('*', Console.WindowWidth);
            Console.WriteLine($"{stars}");
            Console.WriteLine($"* Create PDF option is set.");
            Console.WriteLine($"* The tool will load required assets to create the pdf files.");
            Console.WriteLine($"* Pdf file creation takes some time...");
            Console.WriteLine($"{stars}");
            Console.ForegroundColor = ccolor;
        }
        if (verbose)
        {
            Console.WriteLine($"- reading test summary file '{submissionSummaryFile}' from selected submissions");
            Console.WriteLine();
        }

        foreach (var submission in answerDirectories)
        {
            var testSummary = Path.Combine(submission.FullName, submissionSummaryFile);
            if (File.Exists(testSummary))
            {
                var testRunSummary = JsonSerializer.Deserialize<TestRunSummary>(await File.ReadAllTextAsync(testSummary));
                var mdFile = GetMdFilename(submission, mdPrefix, mdRegex, mdSuffix) ?? Path.ChangeExtension(submissionSummaryFile, ".md");
                mdFile = Path.Combine(destinationPath ?? submission.FullName, mdFile);
                DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(mdFile));
                if (false == di.Exists)
                {
                    di.Create();
                }
                if (verbose)
                {
                    Console.WriteLine($"- converting summary file '{testSummary}' to '{mdFile}'");
                }
                using (StreamWriter sw = new StreamWriter(mdFile, false, Encoding.UTF8))
                {
                    sw.WriteLine($"# {title}");
                    sw.WriteLine();
                    sw.WriteLine($"Points: **{testRunSummary.Points} / {testRunSummary.MaximumPoints}**");
                    sw.WriteLine();
                    sw.WriteLine($"|Test|Points|");
                    sw.WriteLine($"|:---|:----:|");
                    foreach (var item in testRunSummary.SummaryItems)
                    {
                        sw.WriteLine($"|{item.TestName}|{item.Points}|");
                    }
                    sw.WriteLine();
                    sw.WriteLine("## Tests");
                    sw.WriteLine();
                    foreach (var item in testRunSummary.SummaryItems)
                    {
                        int counter = 0;
                        sw.WriteLine($"### {item.TestName}");
                        sw.WriteLine();
                        sw.WriteLine($"Points: **{item.Points}**");
                        sw.WriteLine();
                        sw.WriteLine($"{item.Counters}");
                        sw.WriteLine();
                        foreach (var output in item.Outputs)
                        {
                            sw.WriteLine($"{++counter}. {output.Info}");
                            sw.WriteLine();
                            sw.WriteLine($"\t```");
                            sw.WriteLine($"\t{output.Message.Replace("\n", "\n\t")}");
                            sw.WriteLine($"\t```");
                            sw.WriteLine();
                        }
                    }
                }
                if (createPdf)
                {
                    await ConvertMarkdownToPdf($"{title} - {Path.GetFileNameWithoutExtension(mdFile)}", mdFile, createPdfKeepHtml);
                }
            }
        }
    }

    private string? GetMdFilename(DirectoryInfo submission, string? mdPrefix, string? mdRegex, string? mdSuffix)
    {
        string? studentId = string.IsNullOrEmpty(mdRegex) ? null : Regex.Match(submission.Name, mdRegex).Value;
        string? fileName = $"{mdPrefix}{studentId}{mdSuffix}";
        if (string.IsNullOrEmpty(fileName))
        {
            return null;
        }
        return Path.ChangeExtension(fileName, MD_FILE_EXTENSION);
    }

    private async Task<string?> ConvertMarkdownToPdf(string title, string mdFile, bool keepHtml)
    {
        var options = new Markdown2PdfOptions
        {
            DocumentTitle = title,
            MarginOptions = new MarginOptions
            {
                Top = "80px",
                Bottom = "50px",
                Left = "50px",
                Right = "50px"
            },
            KeepHtml = keepHtml
        };
        var converter = new Markdown2PdfConverter(options);
        var resultPath = await converter.Convert(mdFile);
        return resultPath;
    }
}
