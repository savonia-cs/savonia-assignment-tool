namespace Savonia.Assignment.Tool.Helpers;

public static class CommonHelpers
{
    /// <summary>
    /// Convert seconds to milliseconds.
    /// </summary>
    public static int SecondsToMs(this int seconds) => seconds * 1000;

    /// <summary>
    /// Convert bytes to Base64 encoded string with URL safe characters.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string ToBase64UrlEncoded(this byte[] bytes) => Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').Replace("=", "");
}

