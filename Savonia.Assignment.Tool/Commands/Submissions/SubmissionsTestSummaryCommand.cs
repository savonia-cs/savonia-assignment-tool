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

namespace Savonia.Assignment.Tool.Commands.Submissions;

public class SubmissionsTestSummaryCommand : Command
{
    // savoniatool submissions test summary <sourcePath> <resultSummaryCsvFile> --selected-submissions 1-10 --test-summary-file testrunsummary.json

    public SubmissionsTestSummaryCommand() : base("summary", "Collect test run summaries in submission folders and create summary file.")
    {
        var resultSummaryArgument = new Argument<string?>("resultSummaryCsvFile")
        {
            Description = "Result summary file. By default the csv file is named the same as the source folder name.",
            DefaultValueFactory = parseResult => null
        };

        var testSummaryFileOption = new Option<string>("--test-summary-file")
        {
            Description = "Test summary file name to read each submission's test run summary from.",
            DefaultValueFactory = ParseResult => "testrunsummary.json"
        };

        var resultSummaryIsCSVOption = new Option<bool>("--csv")
        {
            Description = "Result summary file is CSV file by default. Set to false to create TSV file.",
            DefaultValueFactory = ParseResult => true
        };

        var selectedSubmissionsOption = new Option<List<string>?>("--selected-submissions")
        {
            Description = "Set index number of submission folders to include in summary. Use 'submissions list' command to see the numbers. Use single number (i.e. 3 4 8) to select individual folders. Use dash (-) to select a range of folders (i.e. 1-10 14-16) or use dash with one number to select from start or to end (i.e. -10 15-). Leave empty to select all folders.",
            DefaultValueFactory = ParseResult => new List<string> { },
            AllowMultipleArgumentsPerToken = true
        };

        var moodleCsvFileOption = new Option<FileInfo?>("--moodle-csv")
        {
            Description = "A CSV file from Moodle LMS to combine the results with. When set, the results are combined to the defined file. The file is expected to contain submissions info from Moodle.",
            DefaultValueFactory = ParseResult => null
        };
    
        moodleCsvFileOption.Validators.Add(result =>
        {
            var fi = result.GetValueOrDefault<FileInfo>();
            if (fi is not null)
            {
                var file = fi.FullName ?? string.Empty;
                if (false == File.Exists(file))
                {
                    result.AddError($"Moodle CSV file '{file}' does not exist.");
                }
            }
        });

        var moodleCsvStudentIdentifierRegexOption = new Option<string>("--moodle-csv-student-identifier-regex")
        {
            Description = "A regex to get student identifier from submission folder name.",
            DefaultValueFactory = ParseResult => "(?<=_)[0-9]+(?=_)"
        };

        var moodleCsvStudentIdentifierPrefixOption = new Option<string>("--moodle-csv-student-identifier-prefix")
        {
            Description = "Prefix to append to the student identifier to match a row in the Moodle CSV file. By default this is 'Opiskelija' for Finnish CSV file and 'Participant ' for English CSV file (notice the white space in the English version!).",
            DefaultValueFactory = ParseResult => "Opiskelija"
        };

        var moodleCsvAppendIdToFeedbackFieldOption = new Option<bool>("--moodle-csv-append-id-to-feedback")
        {
            Description = "Append student identifier to the feedback field in Moodle CSV file.",
            DefaultValueFactory = ParseResult => false
        };

        var moodleCsvFeedbackFieldIdPrefixOption = new Option<string>("--moodle-csv-feedback-id-prefix")
        {
            Description = "Prefix text to add to student identifier in feedback field.",
            DefaultValueFactory = ParseResult => ""
        };

        var moodleCsvFeedbackFieldIdSuffixOption = new Option<string>("--moodle-csv-feedback-id-suffix")
        {
            Description = "Suffix text to add to student identifier in feedback field.",
            DefaultValueFactory = ParseResult => ""
        };

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

        this.SetAction(async (parseResult) =>
            {
                await Handle(parseResult.GetValue(CommonArguments.SourcePathArgument)!,
                                 parseResult.GetValue(resultSummaryArgument)!,
                                 parseResult.GetValue(testSummaryFileOption)!,
                                 parseResult.GetValue(resultSummaryIsCSVOption),
                                 parseResult.GetValue(selectedSubmissionsOption),
                                 parseResult.GetValue(moodleCsvFileOption),
                                 parseResult.GetValue(moodleCsvStudentIdentifierRegexOption)!,
                                 parseResult.GetValue(moodleCsvStudentIdentifierPrefixOption)!,
                                 parseResult.GetValue(moodleCsvAppendIdToFeedbackFieldOption),
                                 parseResult.GetValue(moodleCsvFeedbackFieldIdPrefixOption),
                                 parseResult.GetValue(moodleCsvFeedbackFieldIdSuffixOption),
                                 parseResult.GetValue(GlobalOptions.VerboseOption));
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
                        string feedback = testRunSummary.Feedback ?? string.Empty;
                        if (testRunSummary.SummaryItems.Any())
                        {
                            if (string.IsNullOrEmpty(feedback))
                            {
                                feedback = $"{string.Join(", ", testRunSummary.SummaryItems.Select(s => $"{s.TestName}: {s.Points}"))}";
                            }
                            else
                            {
                                feedback = $"{feedback} - {string.Join(", ", testRunSummary.SummaryItems.Select(s => $"{s.TestName}: {s.Points}"))}";
                            }
                            
                        }
                        csvWriter.WriteField(feedback);

                        if (moodleCsv is not null)
                        {
                            FillPointsToMoodleCsv(moodleCsvContent,
                                                    submission,
                                                    moodleIdentifierRegex,
                                                    moodleIdentifierPrefix,
                                                    testRunSummary.Points,
                                                    feedback,
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
                                        int points,
                                        string feedback,
                                        bool moodleAppendIdToFeedback,
                                        string? moodleFeedbackIdPrefix,
                                        string? moodleFeedbackIdSuffix,
                                        bool verbose)
    {
        var studentId = Regex.Match(submission.Name, moodleRegex).Value;
        var moodleRow = moodleCsvContent.FirstOrDefault(r => r[moodleFieldIndexForId].Equals($"{moodlePrefix}{studentId}"));
        if (null != moodleRow)
        {
            moodleRow[moodleFieldIndexForGrade] = points.ToString();
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
