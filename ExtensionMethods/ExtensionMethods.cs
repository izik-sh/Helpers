public static class ExtensionMethods
{
    public static string RemoveChar(this String str, string charToRemove)
    {
        return str.Replace(charToRemove, string.Empty);
    }
}
