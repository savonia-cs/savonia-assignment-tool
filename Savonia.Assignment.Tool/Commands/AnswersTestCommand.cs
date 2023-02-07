using System.CommandLine;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Xml;
using Microsoft.Extensions.FileSystemGlobbing;
using Savonia.Assignment.Tool.Helpers;

namespace Savonia.Assignment.Tool.Commands;

public class AnswersTestCommand : Command
{
    // savoniatool answers test --result-file "moodle.csv" --path ./ --test-harness "path-to-folder-with-tests" --test-runner python --test-runner-command "python testall.py" --test-points 1 1 1 1 1
    // dotnet test result line regex: .*?\b.*?\bFailed:.*?\b, Passed:.*?\b, Skipped:.*?\b, Total:.*?\b, Duration:.*?\b.dll.*?

    /*
        1. unpack answers 
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

    public AnswersTestCommand() : base("test", "Run tests for each answer and report results to a csv file.")
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
            description: "Points awarded by successfull tests. Use in the same order as tests are defined",
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

        Add(csvOutputOption);
        Add(testHarnessOption);
        Add(testDataPrefixOption);
        Add(testPointsOption);
        Add(CommonOptions.ExcludesOption);
        Add(CommonOptions.IncludesOption);
        Add(testStepsOption);
        Add(testLogfileOption);

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
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            await File.AppendAllLinesAsync(output, resultsWithPoints);
        }
    }

    private List<string> AddTestPointsToResults(List<int> testPoints, bool verbose, List<(string student, string test, string result)> results)
    {
        var groupedByStudent = results.GroupBy(r => r.student);
        List<string> resultStrings = new List<string>();
        foreach (var group in groupedByStudent)
        {
            var points = group.OrderBy(g => g.test).Select((g, i) =>
            {
                var points = i < testPoints.Count ? testPoints[i] : 1; // default to one point per test if no points are defined
                var isPassed = g.result.Equals("completed", StringComparison.InvariantCultureIgnoreCase);
                return (g.test, points: (isPassed ? points : 0));
            });
            resultStrings.Add(string.Join(",", $"\"{group.Key}\"", $"\"{string.Join(", ", points.Select(p => $"{p.test}: {p.points}"))}\"", $"\"{points.Sum(p => p.points)}\""));
        }
        if (verbose)
        {
            Console.WriteLine($"\nCombined test results");
            foreach (var item in resultStrings)
            {
                Console.WriteLine($"- {item}");
            }
        }
        return resultStrings;
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

public enum ResultFileType
{
    // general CSV file
    CSV = 1,
    // CSV file from Savonia's Moodle for an assignment
    Moodle = 2
}

