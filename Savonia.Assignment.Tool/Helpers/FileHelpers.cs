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
}

