using System.CommandLine;
using System.IO.Compression;

namespace Savonia.Assignment.Tool.Commands;

public class AnswersTestCommand : Command
{
    // savoniatool answers test --result-file "moodle.csv" --path ./ --test-harness "path-to-folder-with-tests" --test-runner python --test-runner-command "python testall.py" --test-points 1 1 1 1 1
    // dotnet test result line regex: .*?\b.*?\bFailed:.*?\b, Passed:.*?\b, Skipped:.*?\b, Total:.*?\b, Duration:.*?\b.dll.*?

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

