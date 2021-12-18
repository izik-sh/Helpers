using System.Text.RegularExpressions;

public static class ExtensionMethods
{
    /// <summary>
    /// RemoveChar
    /// </summary>
    /// <param name="str"></param>
    /// <param name="charToRemove"></param>
    /// <returns></returns>
    public static string RemoveChar(this String str, string charToRemove)
    {
        return str.Replace(charToRemove, string.Empty);
    }

    /// <summary>
    /// IsEnglishWord
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEnglishWord(this String str)
    {
        bool results = false;
        try
        {
            Regex regex = new Regex("^[a-z0-9_-]+$");
            Match matchResults = regex.Match(str);
            results = matchResults.Success;
        }
        catch (Exception ex)
        {
            // Throw Error messgae if needed
        }
        return results;
    }
}
