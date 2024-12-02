using System.CommandLine;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Learn.Models;

public class ContentRules
{
    public List<RuleItem> StaticRules { get; set; }
    public List<RuleItem> DynamicRules { get; set; }
}

public class RuleItem {
    public string Name { get; set; }
    public string FeedbackOnFail { get; set; }
    public string? SourceField { get; set; }
    public string Rule { get; set; }
    public bool IgnoreCase { get; set; }
    /// <summary>
    /// Whether the regex should match or not.
    /// </summary>
    public bool Condition { get; set; }


    /// <summary>
    /// Check if the content matches the <see cref="Rule"/> and <see cref="Condition"/>.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool CheckRule(string content) {
        RegexOptions options = IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
        bool regexResult = Regex.IsMatch(content, Rule, options);
        return regexResult == Condition;
    }

    /// <summary>
    /// Check if the content matches the value from <see cref="SourceField"/> and <see cref="Condition"/>.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="sourceValue"></param>
    /// <returns></returns>
    public bool CheckRule(string content, string sourceValue) {
        RegexOptions options = IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
        string pattern = sourceValue.Replace(" ", @"\s");
        bool regexResult = Regex.IsMatch(content, pattern, options);
        return regexResult == Condition;
    }

}

