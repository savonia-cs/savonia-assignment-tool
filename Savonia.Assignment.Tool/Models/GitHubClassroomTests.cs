﻿using System.CommandLine;
using System.Text.Json.Serialization;

namespace Savonia.Assignment.Tool.Models;

/// <summary>
/// GitHub Classroom autograding json file
/// </summary>
public class GitHubClassroomTests
{
    [JsonPropertyName("tests")]
    public List<Test> Tests { get; set; }
    [JsonPropertyName("preparation")]
    public Executable? Preparation { get; set; }
    [JsonPropertyName("cleanup")]
    public Executable? Cleanup { get; set; }
}

public class Executable
{
    [JsonPropertyName("command")]
    public string CommandName { get; set; }
    [JsonPropertyName("arguments")]
    public string? Arguments { get; set; }
    [JsonPropertyName("successExitCode")]
    public int SuccessExitCode { get; set; }
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    public override string ToString()
    {
        return string.Join(' ', CommandName, Arguments);
    }
}

/// <summary>
/// GitHub Classroom autograding test configuration
/// </summary>
public class Test
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("setup")]
    public string Setup { get; set; }
    [JsonPropertyName("run")]
    public string Run { get; set; }
    [JsonPropertyName("input")]
    public string Input { get; set; }
    [JsonPropertyName("output")]
    public string Output { get; set; }
    [JsonPropertyName("comparison")]
    public string Comparison { get; set; }
    [JsonPropertyName("timeout")]
    public int Timeout { get; set; }
    [JsonPropertyName("points")]
    public int Points { get; set; }
}