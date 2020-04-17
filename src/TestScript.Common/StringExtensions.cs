namespace SpringlyLang.Common
{
    public static class StringExtensions
    {
        public static string TrimSurroundings(this string text) => text.Trim('\'', '"');
    }
}
