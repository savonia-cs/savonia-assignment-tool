using System.CommandLine;
using System.Text.Json.Serialization;

namespace Savonia.Assignment.Tool.Models;

public class TestRunSummary
{
    public string Submission { get; set; }
    public DateTime TestRunTime { get; set; }
    public List<TestRunSummaryItem> SummaryItems { get; set; } = new List<TestRunSummaryItem>();
    public int MaximumPoints { get; set; }
    public int Points { get; set; }
}

public class TestRunSummaryItem
{
    public string TestName { get; set; }
    public string RunCommand { get; set; }
    public int RunnerExitCode { get; set; } = -1;
    public string Outcome { get; set; }
    public string Counters { get; set; }
    public int Points { get; set; } = 0;
    public List<TestRunOutput> Outputs { get; set; } = new List<TestRunOutput>();
}

public class TestRunOutput
{
    public string Info { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
}