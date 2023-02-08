using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using NReco.Csv;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class SubmissionsTestCommand : Command
{
    // savoniatool submissions test --result-file "moodle.csv" --path ./ --test-harness "path-to-folder-with-tests" --test-runner python --test-runner-command "python testall.py" --test-points 1 1 1 1 1
    // dotnet test result line regex: .*?\b.*?\bFailed:.*?\b, Passed:.*?\b, Skipped:.*?\b, Total:.*?\b, Duration:.*?\b.dll.*?

    /*
        1. unpack submissions 
        2. set environment variable TEST_DATA_PREFIX=real to run tests with realtestdata.csv|json
        3. copy tests and project files to each answer folder
            3.1. exclude bin, obj, TestResults, src, solution folders when copying tests and project files
            3.2. the result should be: student's answers as source code and tests + project(s) (*.csproj) from teacher
        4. run tests with trx logger: dotnet test --logger "trx;logfilename=2023-02-03-results.trx"
            4.1. tests are run in folder with *.sln file. It is assumed that the solution file contains also the test project(s).
            4.2. OR use similar json as GitHub Classroom test runner where the tests and points are defined?
        5. gather the results and combine with points to a csv file from each TestResults folder under the tests in the current answer
            5.1. use path as student identifier
    */

    public SubmissionsTestCommand() : base("test", "Run tests for each answer and report results to a csv file.")
    {
        var csvOutputOption = new Option<string>(
            name: "--output",
            description: "Output csv file. This will overwrite possible existing file.",
            getDefaultValue: () => "result.csv");
        csvOutputOption.AddAlias("-o");

        var testHarnessOption = new Option<DirectoryInfo>(
            name: "--test-harness",
            description: "Path to directory from where to copy the test harnes to each answer folder.",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    result.ErrorMessage = "Test harness path is not specified. Use --test-harness option.";
                    return null;
                }
                string? path = result.Tokens.Single().Value;
                if (!Directory.Exists(path))
                {
                    result.ErrorMessage = "Directory does not exist";
                    return null;
                }
                else
                {
                    return new DirectoryInfo(path);
                }
            });

        var testDataPrefixOption = new Option<string>(
            name: "--test-data-prefix",
            description: "Prefix to add to test data file names before reading the test data. Is used to run tests with different test data.",
            getDefaultValue: () => "");

        var testPointsOption = new Option<List<int>>(
            name: "--test-points",
            description: "Points awarded by successfull tests. Use in the same order as tests are defined. One point per test is used as default if nothing is set here.",
            getDefaultValue: () => new List<int> { })
        {
            AllowMultipleArgumentsPerToken = true
        };

        var testStepsOption = new Option<TestSteps>(
            name: "--steps",
            description: "Test steps to run.",
            getDefaultValue: () => TestSteps.All);

        var testLogfileOption = new Option<string>(
            name: "--test-log-file",
            description: "Test log file name used to write and read test results. The file is relative to TestResults folder in each test directory.",
            getDefaultValue: () => "savoniatool.trx");

        var moodleCsvInputOption = new Option<string>(
            name: "--moodle-csv",
            description: "Moodle csv file. When the file exists the test results are combined with this file.",
            getDefaultValue: () => "");

        Add(csvOutputOption);
        Add(testHarnessOption);
        Add(testDataPrefixOption);
        Add(testPointsOption);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);
        Add(testStepsOption);
        Add(testLogfileOption);
        Add(moodleCsvInputOption);

        this.SetHandler(async (context) =>
            {
                await Handle(context.ParseResult.GetValueForOption(GlobalOptions.SourcePathOption)!,
                                 context.ParseResult.GetValueForOption(csvOutputOption)!,
                                 context.ParseResult.GetValueForOption(testHarnessOption),
                                 context.ParseResult.GetValueForOption(testDataPrefixOption),
                                 context.ParseResult.GetValueForOption(testPointsOption),
                                 context.ParseResult.GetValueForOption(CommonOptions.IncludesOption)!,
                                 context.ParseResult.GetValueForOption(CommonOptions.ExcludesOption)!,
                                 context.ParseResult.GetValueForOption(testStepsOption),
                                 context.ParseResult.GetValueForOption(testLogfileOption),
                                 context.ParseResult.GetValueForOption(moodleCsvInputOption),
                                 context.ParseResult.GetValueForOption(GlobalOptions.VerboseOption));
            });
    }

    async Task Handle(DirectoryInfo path,
                        string output,
                        DirectoryInfo testHarness,
                        string testDataPrefix,
                        List<int> testPoints,
                        List<string> includes,
                        List<string> excludes,
                        TestSteps steps,
                        string logfile,
                        string moodleCsvInput,
                        bool verbose)
    {
        if (steps == TestSteps.None)
        {
            // no action is specified
            Console.WriteLine($"No action is specified in --steps option. Please, use one or combination from {string.Join(" ", Enum.GetNames<TestSteps>())}");
            return;
        }

        Directory.SetCurrentDirectory(path.FullName);
        var answerDirectories = path.GetDirectories();

        if (steps.HasFlag(TestSteps.Copy))
        {
            Matcher matcher = new Matcher();
            matcher.AddIncludePatterns(includes);
            matcher.AddExcludePatterns(excludes);
            var testHarnessFilesToCopy = matcher.GetResultsInFullPath(testHarness.FullName).ToList();
            CopyTestHarness(testHarness, verbose, testHarnessFilesToCopy, answerDirectories);
        }

        if (steps.HasFlag(TestSteps.Test))
        {
            // run tests
            await RunTests(testDataPrefix, verbose, answerDirectories, logfile);
        }
        if (steps.HasFlag(TestSteps.Results))
        {
            // parse results summary from log files
            var results = GetTestResults(path, logfile, verbose);
            var resultsWithPoints = AddTestPointsToResults(testPoints, verbose, results);
            await WriteResultFile(output, resultsWithPoints, moodleCsvInput, verbose);
        }
    }

    private async Task WriteResultFile(string output, List<(string student, int totalPoints, string testsSummary)> resultsWithPoints, string moodleCsvInput, bool verbose)
    {
        if (string.IsNullOrWhiteSpace(moodleCsvInput))
        {
            // write results to common CSV file
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            using (var sw = new StreamWriter(File.OpenWrite(output)))
            {
                var csvWriter = new CsvWriter(sw);
                foreach (var item in resultsWithPoints)
                {
                    csvWriter.WriteField(item.student);
                    csvWriter.WriteField(item.testsSummary);
                    csvWriter.WriteField(item.totalPoints.ToString());
                    csvWriter.NextRecord();
                }
            }
        }
        else
        {
            // combine results to moodle csv file
            if (false == File.Exists(moodleCsvInput))
            {
                Console.WriteLine($"Moodle file '{moodleCsvInput}' does not exist. Cannot combine results to the file.");
                return;
            }
            List<string[]> moodleContent = new List<string[]>();
            int moodleCsvFieldsCount = 0;
            using (var streamRdr = new StreamReader(File.OpenRead(moodleCsvInput)))
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
            int moodleFieldIndexForId = 0;
            int moodleFieldIndexForName = 1;
            int moodleFieldIndexForGrade = 4;
            int moodleFieldIndexForFeedbackComments = moodleCsvFieldsCount - 1; // the last field
            
            char studentTokenizer = '_';
            int studentIdTokenIndex = 1;

            if (verbose)
            {
                Console.WriteLine($"\nMoodle content");
                int counter = 1;
                foreach (var row in moodleContent)
                {
                    Console.WriteLine($"{counter++,4}: {string.Join("|", row)}");
                }

                Console.WriteLine($"\nResult tokens");
            }

            foreach (var item in resultsWithPoints)
            {
                var tokens = item.student.Split(studentTokenizer, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (verbose)
                {
                    Console.WriteLine($"{string.Join("|", tokens)}");
                }
                var moodleRow = moodleContent.FirstOrDefault(r => r[moodleFieldIndexForId].Contains(tokens[studentIdTokenIndex]));
                if (null != moodleRow)
                {
                    moodleRow[moodleFieldIndexForGrade] = item.totalPoints.ToString();
                    moodleRow[moodleFieldIndexForFeedbackComments] = item.testsSummary;
                }
            }
            using (var sw = new StreamWriter(File.OpenWrite(output)))
            {
                var csvWriter = new CsvWriter(sw);
                foreach (var row in moodleContent)
                {
                    foreach (var col in row)
                    {
                        csvWriter.WriteField(col);    
                    }
                    csvWriter.NextRecord();
                }
            }            
        }
    }

    private List<(string student, int totalPoints, string testsSummary)> AddTestPointsToResults(List<int> testPoints, bool verbose, List<(string student, string test, string result)> results)
    {
        var groupedByStudent = results.GroupBy(r => r.student);
        List<(string student, int totalPoints, string testsSummary)> result = new List<(string, int, string)>();
        foreach (var group in groupedByStudent)
        {
            var points = group.OrderBy(g => g.test).Select((g, i) =>
            {
                var points = i < testPoints.Count ? testPoints[i] : 1; // default to one point per test if no points are defined
                var isPassed = g.result.Equals("completed", StringComparison.InvariantCultureIgnoreCase);
                return (g.test, points: (isPassed ? points : 0));
            });
            result.Add((group.Key, points.Sum(p => p.points), $"{string.Join(", ", points.Select(p => $"{p.test}: {p.points}"))}"));
        }
        if (verbose)
        {
            Console.WriteLine($"\nCombined test results");
            foreach (var item in result)
            {
                Console.WriteLine($"- {item.student}, {item.totalPoints}, {item.testsSummary}");
            }
        }
        return result;
    }

    private List<(string student, string test, string result)> GetTestResults(DirectoryInfo path, string logfile, bool verbose)
    {
        if (verbose)
        {
            Console.WriteLine($"\nCombining results");
        }
        Matcher logFilesMatcher = new Matcher();
        logFilesMatcher.AddInclude($"**/TestResults/{logfile}");

        var pathParts = path.DirectorySplit();
        List<(string, string, string)> results = new List<(string, string, string)>();
        foreach (var testResult in logFilesMatcher.GetResultsInFullPath(path.FullName))
        {
            var relative = Path.GetRelativePath(path.FullName, testResult);
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(testResult));
            var testResultParts = di.DirectorySplit();
            var parts = testResultParts.Except(pathParts);
            // test folder name is in index 1 (index 0 is the TestResults folder), student is in the last index
            var student = parts.Last();
            // NOTE! it is assumed that parts has more than two (2) items.
            var test = parts.Skip(1).First();

            // load test results trx file
            XmlDocument doc = new XmlDocument();
            doc.Load(testResult);
            var xmlns = doc.DocumentElement.Attributes.GetNamedItem("xmlns");
            XmlNode? resultNode = null;
            if (null != xmlns)
            {
                XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
                mgr.AddNamespace("ns", xmlns.Value);
                resultNode = doc.SelectSingleNode("//ns:ResultSummary", mgr);
            }
            else
            {
                resultNode = doc.SelectSingleNode("//ResultSummary");
            }
            var resultValue = resultNode?.Attributes.GetNamedItem("outcome");
            if (verbose)
            {
                Console.WriteLine($"- {student} / {test} = {resultValue?.Value}");
            }
            results.Add((student, test, resultValue?.Value));
        }
        return results;
    }

    private async Task RunTests(string testDataPrefix, bool verbose, DirectoryInfo[] answerDirectories, string logfile)
    {
        // run tests on each answer directory
        bool testDataPrefixHasValue = false == string.IsNullOrEmpty(testDataPrefix);
        if (verbose)
        {
            Console.WriteLine($"\nRunning tests");
            if (testDataPrefixHasValue)
            {
                Console.WriteLine($"- Setting environment variable TEST_DATA_PREFIX={testDataPrefix}");
            }
        }
        List<Task> testProcesses = new List<Task>();
        foreach (var answerDir in answerDirectories)
        {
            if (verbose)
            {
                Console.WriteLine($"- {answerDir.Name}");
            }
            ProcessStartInfo psi = new ProcessStartInfo(@"dotnet", $"test --logger \"trx;logfilename={logfile}\"");
            psi.WorkingDirectory = answerDir.FullName;
            if (testDataPrefixHasValue)
            {
                psi.EnvironmentVariables.Add("TEST_DATA_PREFIX", testDataPrefix);
            }
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            var p = Process.Start(psi);
            testProcesses.Add(p.WaitForExitAsync());
        }
        await Task.WhenAll(testProcesses.ToArray());
    }

    private void CopyTestHarness(DirectoryInfo testHarness, bool verbose, List<string> testHarnessFilesToCopy, DirectoryInfo[] answerDirectories)
    {
        if (verbose)
        {
            Console.WriteLine($"Copying test harness files from {testHarness.FullName}:");
            foreach (var item in testHarnessFilesToCopy)
            {
                Console.WriteLine($"- {Path.GetRelativePath(testHarness.FullName, item)}");
            }
            Console.WriteLine($"to:");
        }

        foreach (var answerDir in answerDirectories)
        {
            if (verbose)
            {
                Console.WriteLine($"- {answerDir.Name}");
            }
            foreach (string file in testHarnessFilesToCopy)
            {
                string relativeFile = Path.GetRelativePath(testHarness.FullName, file);
                FileInfo sourceFile = new FileInfo(file);
                string destinationFile = Path.Combine(answerDir.FullName, relativeFile);
                DirectoryInfo destinationPath = new DirectoryInfo(Path.GetDirectoryName(destinationFile));
                if (verbose)
                {
                    // Console.WriteLine($"    {Path.Combine(testHarness.Name, relativeFile)} {Path.Combine(answerDir.Name, relativeFile)}");
                    Console.WriteLine($"    {relativeFile}");
                }
                if (false == destinationPath.Exists)
                {
                    destinationPath.Create();
                }
                sourceFile.CopyTo(destinationFile, true);
            }
        }
    }
}

[Flags]
public enum TestSteps
{
    None = 0,
    Copy = 1,
    Test = 2,
    Results = 4,
    All = Copy | Test | Results
}


