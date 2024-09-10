using System.Xml.Serialization;
using VSTest;
using NReco.Csv;
using System.Text.RegularExpressions;

namespace Savonia.Assignment.Tool.Helpers;

public static class CsvHelpers
{
    public static readonly Dictionary<string, string> PredefinedRegexes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "URL", @"(https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])"}
    };

    /// <summary>
    /// Get header row from csv content or generate numerical header row is none is present.
    /// </summary>
    /// <param name="csvContent"></param>
    /// <param name="hasHeader"></param>
    /// <returns></returns>
    public static List<string> GetHeaderRow(this List<List<string>> csvContent, bool hasHeader)
    {
        // get header row
        List<string> headerRow = new List<string>();
        if (hasHeader)
        {
            headerRow = csvContent[0];
        }
        else
        {
            headerRow = Enumerable.Range(1, csvContent[0].Count).Select(i => i.ToString()).ToList();
        }        
        return headerRow;
    }

    public static async Task LoadRegexes(this FileInfo? regexInput)
    {
        // load possible regexes from JSON file
        if (null != regexInput)
        {
            Dictionary<string, string>? regexes = await System.Text.Json.JsonSerializer.DeserializeAsync<Dictionary<string, string>>(regexInput.OpenRead());
            if (null != regexes && regexes.Count > 0)
            {
                foreach (var key in regexes.Keys)
                {
                    PredefinedRegexes[key] = regexes[key];
                }
            }
        }
    }

    public static string GetFieldValue(this string sourceFieldValue, int fieldIndex, Dictionary<int, string> fieldRegexes)
    {
        if (fieldRegexes.Count > 0 && fieldRegexes.ContainsKey(fieldIndex))
        {
            Match m = Regex.Match(sourceFieldValue, fieldRegexes[fieldIndex], RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return m.Value;
            }
        }
        return sourceFieldValue;
    }

    public static Dictionary<int, string> GetFieldRegexes(this List<string> fieldFilters, List<string> headerRow)
    {
        // parse field filters
        var fieldRegexes = new Dictionary<int, string>();
        if (fieldFilters != null)
        {
            for (int i = 0; i < fieldFilters.Count; i += 2)
            {
                // assume that values are in pairs where first value is field number or name and the second is the regex (e.g. --field-filters 3 \\d to select only numbers from field 3)
                if (fieldFilters.Count > i + 1)
                {
                    var fieldName = fieldFilters[i];
                    var regex = fieldFilters[i + 1];
                    int fieldIndex = GetFieldIndex(headerRow, fieldName);
                    if (fieldIndex > -1)
                    {
                        if (PredefinedRegexes.ContainsKey(regex))
                        {
                            regex = PredefinedRegexes[regex];
                        }
                        fieldRegexes.Add(fieldIndex, regex);
                    }
                }
            }
        }
        return fieldRegexes;
    }

    public static int GetFieldIndex(this List<string> headerRow, string fieldName)
    {
        if (int.TryParse(fieldName, out int fieldNumber) && fieldNumber > 0 && fieldNumber <= headerRow.Count)
        {
            return fieldNumber - 1;
        }
        else
        {
            var fieldIndex = headerRow.IndexOf(fieldName);
            return fieldIndex;
        }
    }

}

