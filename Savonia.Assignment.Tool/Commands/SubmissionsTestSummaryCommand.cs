using System.CommandLine;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
            description: "Test summary file name to read each submission's test run summary from.",
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

        var moodleCsvFileOption = new Option<FileInfo?>(
            name: "--moodle-csv",
            description: "A CSV file from Moodle LMS to combine the results with. When set, the results are combined to the defined file. The file is expected to contain submissions info from Moodle.",
            getDefaultValue: () => null);

        moodleCsvFileOption.AddValidator(result =>
        {
            var fi = result.GetValueForOption(moodleCsvFileOption);
            if (fi is not null)
            {
                var file = fi.FullName ?? string.Empty;
                if (false == File.Exists(file))
                {
                    result.ErrorMessage = $"Moodle CSV file '{file}' does not exist.";
                }
            }
        });

        var moodleCsvStudentIdentifierRegexOption = new Option<string>(
            name: "--moodle-csv-student-identifier-regex",
            description: "A regex to get student identifier from submission folder name.",
            getDefaultValue: () => "(?<=_)[0-9]+(?=_)");

        var moodleCsvStudentIdentifierPrefixOption = new Option<string>(
            name: "--moodle-csv-student-identifier-prefix",
            description: "Prefix to append to the student identifier to match a row in the Moodle CSV file. By default this is 'Opiskelija' for Finnish CSV file and 'Participant ' for English CSV file (notice the white space in the English version!).",
            getDefaultValue: () => "Opiskelija");

        var moodleCsvAppendIdToFeedbackFieldOption = new Option<bool>(
            name: "--moodle-csv-append-id-to-feedback",
            description: "Append student identifier to the feedback field in Moodle CSV file.",
            getDefaultValue: () => false);

        var moodleCsvFeedbackFieldIdPrefixOption = new Option<string>(
            name: "--moodle-csv-feedback-id-prefix",
            description: "Prefix text to add to student identifier in feedback field.",
            getDefaultValue: () => "");

        var moodleCsvFeedbackFieldIdSuffixOption = new Option<string>(
            name: "--moodle-csv-feedback-id-suffix",
            description: "Suffix text to add to student identifier in feedback field.",
            getDefaultValue: () => "");

        Add(CommonArguments.SourcePathArgument);
        Add(resultSummaryArgument);
        Add(testSummaryFileOption);
        Add(resultSummaryIsCSVOption);
        Add(selectedSubmissionsOption);
        Add(moodleCsvFileOption);
        Add(moodleCsvStudentIdentifierRegexOption);
        Add(moodleCsvStudentIdentifierPrefixOption);
        Add(moodleCsvAppendIdToFeedbackFieldOption);
        Add(moodleCsvFeedbackFieldIdPrefixOption);
        Add(moodleCsvFeedbackFieldIdSuffixOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForArgument(CommonArguments.SourcePathArgument)!,
                                 context.ParseResult.GetValueForArgument(resultSummaryArgument)!,
                                 context.ParseResult.GetValueForOption(testSummaryFileOption)!,
                                 context.ParseResult.GetValueForOption(resultSummaryIsCSVOption),
                                 context.ParseResult.GetValueForOption(selectedSubmissionsOption),
                                 context.ParseResult.GetValueForOption(moodleCsvFileOption),
                                 context.ParseResult.GetValueForOption(moodleCsvStudentIdentifierRegexOption)!,
                                 context.ParseResult.GetValueForOption(moodleCsvStudentIdentifierPrefixOption)!,
                                 context.ParseResult.GetValueForOption(moodleCsvAppendIdToFeedbackFieldOption),
                                 context.ParseResult.GetValueForOption(moodleCsvFeedbackFieldIdPrefixOption),
                                 context.ParseResult.GetValueForOption(moodleCsvFeedbackFieldIdSuffixOption),
                                 context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(DirectoryInfo path,
                        string resultSummaryFile,
                        string submissionSummaryFile,
                        bool isCsv,
                        List<string>? selectedSubmissions,
                        FileInfo? moodleCsv,
                        string moodleIdentifierRegex,
                        string moodleIdentifierPrefix,
                        bool moodleAppendIdToFeedback,
                        string? moodleFeedbackIdPrefix,
                        string? moodleFeedbackIdSuffix,
                        bool verbose)
    {
        DirectoryInfo[] answerDirectories = SubmissionsTestCommand.SelectSubmissionFolders(path, selectedSubmissions, verbose);
        List<string[]> moodleCsvContent = new List<string[]>();
        // create result summary file
        Console.WriteLine($"Creating summary to file '{resultSummaryFile}' from submissions in '{path.Name}'.");
        if (moodleCsv is not null)
        {
            Console.WriteLine($"- combining summary with Moodle CSV file '{moodleCsv.Name}'. Resulting file is '{GetMoodleSummaryFilename(moodleCsv)}'.");
            moodleCsvContent = ReadMoodleCsvFile(moodleCsv, verbose);
        }
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

                        if (moodleCsv is not null)
                        {
                            FillPointsToMoodleCsv(moodleCsvContent, 
                                                    submission, 
                                                    moodleIdentifierRegex, 
                                                    moodleIdentifierPrefix, 
                                                    testRunSummary, 
                                                    moodleAppendIdToFeedback, 
                                                    moodleFeedbackIdPrefix, 
                                                    moodleFeedbackIdSuffix, 
                                                    verbose);
                        }
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
        if (moodleCsv is not null)
        {
            WriteMoodleCsvResultsFile(moodleCsv, moodleCsvContent);
        }
    }

    private void WriteMoodleCsvResultsFile(FileInfo moodleCsv, List<string[]> moodleCsvContent)
    {
        string newFileName = GetMoodleSummaryFilename(moodleCsv);
        using (var sw = new StreamWriter(File.OpenWrite(newFileName)))
        {
            var csvWriter = new CsvWriter(sw, ",");
            foreach (var row in moodleCsvContent)
            {
                foreach (var col in row)
                {
                    csvWriter.WriteField(col);
                }
                csvWriter.NextRecord();
            }
        }
    }

    private string GetMoodleSummaryFilename(FileInfo moodleCsv)
    {
        string extension = Path.GetExtension(moodleCsv.FullName);
        string fileName = Path.GetFileNameWithoutExtension(moodleCsv.FullName);
        string newFileName = $"{fileName}_output{extension}";
        return newFileName;
    }

    private int moodleFieldIndexForId = 0;
    private int moodleFieldIndexForGrade = 4;
    int moodleFieldIndexForFeedbackComments; // will be populated in ReadMoodleCsvFile method

    private void FillPointsToMoodleCsv(List<string[]> moodleCsvContent, 
                                        DirectoryInfo submission, 
                                        string moodleRegex, 
                                        string moodlePrefix, 
                                        TestRunSummary testRunSummary, 
                                        bool moodleAppendIdToFeedback,
                                        string? moodleFeedbackIdPrefix,
                                        string? moodleFeedbackIdSuffix,
                                        bool verbose)
    {
        var studentId = Regex.Match(submission.Name, moodleRegex).Value;
        var moodleRow = moodleCsvContent.FirstOrDefault(r => r[moodleFieldIndexForId].Equals($"{moodlePrefix}{studentId}"));
        if (null != moodleRow)
        {
            moodleRow[moodleFieldIndexForGrade] = testRunSummary.Points.ToString();
            string feedback = string.Join(", ", testRunSummary.SummaryItems.Select(s => $"{s.TestName}: {s.Points}"));
            if (moodleAppendIdToFeedback)
            {
                feedback = $"{feedback} - {moodleFeedbackIdPrefix}{studentId}{moodleFeedbackIdSuffix}";
            }
            moodleRow[moodleFieldIndexForFeedbackComments] = feedback;
        }
    }

    private List<string[]> ReadMoodleCsvFile(FileInfo moodleCsv, bool verbose)
    {
        List<string[]> moodleContent = new List<string[]>();
        int moodleCsvFieldsCount = 0;
        using (var streamRdr = new StreamReader(File.OpenRead(moodleCsv.FullName)))
        {
            var csvReader = new CsvReader(streamRdr, ",");
            while (csvReader.Read())
            {
                moodleCsvFieldsCount = csvReader.FieldsCount;
                string[] row = new string[moodleCsvFieldsCount];
                for (int i = 0; i < moodleCsvFieldsCount; i++)
                {
                    row[i] = csvReader[i];
                }
                moodleContent.Add(row);
            }
        }
        moodleFieldIndexForFeedbackComments = moodleCsvFieldsCount - 1; // the last field
        return moodleContent;
    }
}
