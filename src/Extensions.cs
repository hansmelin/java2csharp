using System.Text.RegularExpressions;

namespace Java2csharp
{
    internal static class Extensions
    {
        /// <summary>
        ///     Converts keywords, type names and array types
        /// </summary>
        /// <param name="oldKeyword"></param>
        /// <param name="newKeyword"></param>
        /// <param name="code"></param>
        public static string ConvertKeyword(this string code, string oldKeyword, string newKeyword)
        {
            var regex = new Regex(@"([\s(])" + oldKeyword + @"([\s\[])", RegexOptions.Multiline);
            return regex.Replace(code, "$1" + newKeyword + "$2");
        }

        /// <summary>
        /// Convert class names
        /// </summary>
        /// <param name="code"></param>
        /// <param name="oldKeyword"></param>
        /// <param name="newKeyword"></param>
        /// <returns></returns>
        public static string ConvertClassName(this string code, string oldKeyword, string newKeyword)
        {
            var regex = new Regex(@"([\s<,(])" + oldKeyword + @"([,\s\[\)\(\.<>])", RegexOptions.Multiline);
            return regex.Replace(code, "$1" + newKeyword + "$2");
        }
    }
}