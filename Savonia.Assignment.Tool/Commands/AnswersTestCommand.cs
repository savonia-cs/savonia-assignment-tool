using System.CommandLine;
using System.IO.Compression;

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
        4. run tests with trx logger: dotnet test --logger "trx;filename=2023-02-03-results.trx"
            4.1. tests are run in folder with *.sln file. It is assumed that the solution file contains also the test project(s).
            4.2. OR use similar json as GitHub Classroom test runner where the tests and points are defined?
        5. gather the results and combine with points to a csv file from each TestResults folder under the tests in the current answer
            5.1. use path as student identifier
    */

    public AnswersTestCommand() : base("test", "Run tests for each answer and report results to a csv file.")
    {
        this.SetHandler(async (path, verbose) =>
            {
                await Handle(path!, verbose);
            },
            GlobalOptions.SourcePathOption, GlobalOptions.VerboseOption);
    }

    async Task Handle(DirectoryInfo path,
                                        bool verbose)
    {
        Console.WriteLine("This will eventually run tests on answers...");
    }
}

