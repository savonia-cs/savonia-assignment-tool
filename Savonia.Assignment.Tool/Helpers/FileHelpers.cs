namespace Savonia.Assignment.Tool.Helpers;

public static class FileHelpers
{
    /// <summary>
    /// Read csv file content and return as list of lists (rows[columns]).
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static async Task<List<List<string>>> ReadCsv(this FileInfo file)
    {
        List<List<string>> data = new List<List<string>>();
        using (var fs = file.OpenRead())
        using (StreamReader sr = new StreamReader(fs))
        {
            string content = await sr.ReadToEndAsync();
            content = content.Replace("\r", "");
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(','); // TODO: handle cases where column content contains comma (,)
                data.Add(columns.Select(c => c.Trim('"')).ToList());
            }
        }
        return data;
    }

    /// <summary>
    /// Split a directory in its components.
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
    /// Return one part of the directory path.
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
}

