using System.CommandLine;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;
using Savonia.Assignment.Tool.Models;
using VSTest;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsTestSummaryCommand : Command
{
    // savoniatool submissions test summary <sourcePath> <resultSummaryCsvFile> --selected-submissions 1-10 --test-summary-file testrunsummary.json

    public SubmissionsTestSummaryCommand() : base("summary", "Collect test run summaries in submission folders and create summary file.")
    {

        var resultSummaryArgument = new Argument<string?>(
            name: "resultSummaryCsvFile",
            description: "Result summary file. By default the csv file is named the same as the source folder name.",
            getDefaultValue: () => null);

        var testSummaryFileOption = new Option<string>(
            name: "--test-summary-file",
            description: "Test summary file name to read submission test run summary from.",
            getDefaultValue: () => "testrunsummary.json");

        var resultSummaryIsCSVOption = new Option<bool>(
            name: "--csv",
            description: "Result summary file is CSV file by default. Set to false to create TSV file.",
            getDefaultValue: () => true);

        var selectedSubmissionsOption = new Option<List<string>?>(
            name: "--selected-submissions",
            description: "Set index number of submission folders to include in summary. Use 'submissions list' command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            getDefaultValue: () => new List<string> { })
        {
            AllowMultipleArgumentsPerToken = true
        };

        Add(CommonArguments.SourcePathArgument);
        Add(resultSummaryArgument);
        Add(testSummaryFileOption);
        Add(resultSummaryIsCSVOption);
        Add(selectedSubmissionsOption);

        this.SetHandler(async (source, resultSummaryFile, submissionSummaryFile, isCsv, selectedSubmissions, verbose) =>
        {
            await Handle(source, resultSummaryFile ?? $"{source.Name}.{(isCsv ? "csv" : "tsv")}", submissionSummaryFile, isCsv, selectedSubmissions, verbose);
        },
        CommonArguments.SourcePathArgument, resultSummaryArgument, testSummaryFileOption, resultSummaryIsCSVOption, selectedSubmissionsOption, GlobalOptions.VerboseOption);

    }

    async Task Handle(DirectoryInfo path,
                        string resultSummaryFile,
                        string submissionSummaryFile,
                        bool isCsv,
                        List<string>? selectedSubmissions,
                        bool verbose)
    {
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);

        // create result summary file
        Console.WriteLine($"Creating summary to file '{resultSummaryFile}' from submissions in '{path.Name}'.");
        if (verbose)
        {
            Console.WriteLine($"- reading test summary file '{submissionSummaryFile}' from selected submissions");
            Console.WriteLine();
        }

        using (var sw = new StreamWriter(File.OpenWrite(resultSummaryFile)))
        {
            var csvWriter = new CsvWriter(sw, isCsv ? "," : "\t");
            csvWriter.WriteField("Task");
            csvWriter.WriteField("Submission");
            csvWriter.WriteField("Points");
            csvWriter.WriteField("Max points");
            csvWriter.WriteField("Info");
            csvWriter.NextRecord();
            foreach (var submission in answerDirectories)
            {
                var testSummary = Path.Combine(submission.FullName, submissionSummaryFile);
                csvWriter.WriteField(path.Name);
                csvWriter.WriteField(submission.Name);
                if (File.Exists(testSummary))
                {
                    var testRunSummary = JsonSerializer.Deserialize<TestRunSummary>(await File.ReadAllTextAsync(testSummary));
                    if (null != testRunSummary)
                    {
                        csvWriter.WriteField(testRunSummary.Points.ToString());
                        csvWriter.WriteField(testRunSummary.MaximumPoints.ToString());
                        csvWriter.WriteField(string.Join(", ", testRunSummary.SummaryItems.Select(s => $"{s.TestName}: {s.Points}")));
                    }
                }
                else
                {
                    csvWriter.WriteField("-");
                    csvWriter.WriteField("-");
                    csvWriter.WriteField("Test run summary file not found.");
                }
                csvWriter.NextRecord();
            }
        }
    }
}
