using System.CommandLine;
using System.Text;
using System.Xml;
using Savonia.Assignment.Tool.Helpers;
using VSTest;

namespace Savonia.Assignment.Tool.Commands.Test;

public class TestTrxToMdCommand : Command
{
    public TestTrxToMdCommand() : base("trxtomd", "Converts a test result file (.trx) to a Markdown file (.md)")
    {
        var sourceArgument = new Argument<FileInfo>(
            name: "sourceTrxFile",
            description: "Source trx file to convert"
            );

        sourceArgument.AddValidator(result =>
        {
            var file = result.GetValueForArgument(sourceArgument).FullName ?? string.Empty;
            if (false == File.Exists(file))
            {
                result.ErrorMessage = $"Source file '{file}' does not exist";
            }
        });

        var destinationArgument = new Argument<string?>(
            name: "destinationMdFile",
            description: "Destination file md file. Default value is the trx file name with .md extension in current folder.",
            getDefaultValue: () => null);

        Add(sourceArgument);
        Add(destinationArgument);

        this.SetHandler(async (source, output, verbose) =>
        {
            await Handle(source!, output ?? $"{Path.GetFileNameWithoutExtension(source.Name)}.md", verbose);
        },
        sourceArgument, destinationArgument, GlobalOptions.VerboseOption);
    }

    async Task Handle(FileInfo source,
                        string target,
                        bool verbose)
    {
        Console.WriteLine($"Converting '{source.Name}' to {target}");
        try
        {
            TestRunType testRun = source.ReadTestRunResults();
            var mdString = new StringBuilder();

            var definitions = testRun.TestDefinitions.FirstOrDefault();
            var unitTest = definitions.UnitTest.FirstOrDefault();
            var summary = testRun.ResultSummary.FirstOrDefault();
            var counters = summary.Counters.FirstOrDefault();
            var results = testRun.Results.FirstOrDefault();
            var testResults = results.UnitTestResult;

            mdString.AppendLine($"## {unitTest.Name} - {summary.Outcome}");
            mdString.AppendLine();
            mdString.AppendLine($"Tests: total {counters.Total}, passed {counters.Passed}, failed {counters.Failed}");
            mdString.AppendLine();
            mdString.AppendLine($"### Test results");
            mdString.AppendLine();
            foreach (var tr in testResults.Where(t => t.Outcome.Equals("failed", StringComparison.OrdinalIgnoreCase)))
            {
                mdString.AppendLine($"{tr.TestName} - {tr.Outcome}");
                mdString.AppendLine();
                var output = tr.Output.FirstOrDefault();
                var errorInfo = output.ErrorInfo;
                var message = errorInfo.Message as XmlNode[];
                var stackTrace = errorInfo.StackTrace as XmlNode[];
                mdString.AppendLine($"{message.FirstOrDefault()?.InnerText}");
                mdString.AppendLine($"StackTrace: {stackTrace.FirstOrDefault()?.InnerText}");
            }

            File.WriteAllText(target, mdString.ToString());
        }
        catch (Exception ex)
        {
            var cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!FAILED to convert file {source.Name}.\n\n{ex.Message}");
            Console.ForegroundColor = cc;
        }
    }
}
