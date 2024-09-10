using System.Xml.Serialization;
using VSTest;
using NReco.Csv;

namespace Savonia.Assignment.Tool.Helpers;

public static class FileHelpers
{
    /// <summary>
    /// Read csv file content and return as list of lists (rows[columns]).
    /// </summary>
    /// <param name="file"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static List<List<string>> ReadCsv(this FileInfo file, string delimiter = ",")
    {
        List<List<string>> csvContent = new List<List<string>>();
        using (var streamRdr = new StreamReader(file.OpenRead()))
        {
            var csvReader = new CsvReader(streamRdr, delimiter);
            while (csvReader.Read())
            {
                List<string> row = new List<string>(csvReader.FieldsCount);
                for (int i = 0; i < csvReader.FieldsCount; i++)
                {
                    string val = csvReader[i];
                    row.Add(val);
                }
                csvContent.Add(row);
            }
        }
        return csvContent;
    }

    /// <summary>
    /// Write csv content to file.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="csvContent"></param>
    /// <param name="delimiter"></param>
    public static void WriteCsv(this string file, List<List<string>> csvContent, string delimiter = ",")
    {
        int columns = csvContent[0].Count;
        using (var sw = new StreamWriter(File.OpenWrite(file)))
        {
            var csvWriter = new CsvWriter(sw, delimiter);
            foreach (var row in csvContent)
            {
                for (int i = 0; i < columns; i++)
                {
                    csvWriter.WriteField(row[i]);
                }
                csvWriter.NextRecord();
            }
        }
    }

    /// <summary>
    /// Split a directory in its components. Note that <see cref="DirectoryInfo"/> is always rooted.
    /// Input e.g: a/b/c/d.
    /// Output: d, c, b, a.
    /// </summary>
    /// <param name="di"></param>
    /// <returns></returns>
    public static IEnumerable<string> DirectorySplit(this DirectoryInfo? di)
    {
        while (di != null)
        {
            yield return di.Name;
            di = di.Parent;
        }
    }

    /// <summary>
    /// Return one part of the directory path. Note that <see cref="DirectoryInfo"/> is always rooted.
    /// Path e.g.: a/b/c/d. PartNr=0 is a, Nr 2 = c.
    /// </summary>
    /// <param name="di"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string DirectoryPart(this DirectoryInfo di, int index)
    {
        string[] parts = di.DirectorySplit().ToArray();
        int l = parts.Length;
        return index >= 0 && index < l ? parts[l - 1 - index] : "";
    }

    /// <summary>
    /// Split sub directory in its components and filter out base directory components resulting in relative directory components.
    /// Returns relative path's components
    /// Input e.g: c:/a/b and c:/a/b/c/d.
    /// Output: d, c.
    /// </summary>
    /// <param name="subDir"></param>
    /// <param name="baseDirParts"></param>
    /// <returns></returns>
    public static IEnumerable<string> DirectorySplit(this DirectoryInfo? subDir, IEnumerable<string> baseDirParts)
    {
        var subParts = subDir.DirectorySplit();
        return subParts.Except(baseDirParts);
    }

    /// <summary>
    /// Return one part of the relative directory path.
    /// Path e.g.: a/b/c/d. PartNr=0 is a, Nr 2 = c.
    /// </summary>
    /// <param name="subDir"></param>
    /// <param name="baseDir"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string DirectoryPart(this DirectoryInfo subDir, IEnumerable<string> baseDirParts, int index)
    {
        string[] parts = subDir.DirectorySplit(baseDirParts).ToArray();
        int l = parts.Length;
        return index >= 0 && index < l ? parts[l - 1 - index] : "";
    }

    public static TestRunType ReadTestRunResults(this FileInfo file)
    {
        TestRunType testRun = new TestRunType();
        using (var fs = file.OpenRead())
        {
            var serializer = new XmlSerializer(typeof(TestRunType));
            testRun = serializer.Deserialize(fs) as TestRunType;
        }
        return testRun;
    }
}

