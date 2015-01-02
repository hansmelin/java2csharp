using System;
using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    /// <summary>
    ///     Targets e.g.: package java.util;
    ///     Converts the target to namespace java.util {
    ///     It also adds a closing bracket } to the end of the file
    /// </summary>
    public class PackageToNamespace
    {
        public string Apply(string code)
        {
            // Convert start name space
            var regex = new Regex(@"package ([a-zA-Z0-9\.]+);", RegexOptions.Multiline);
            string newCode = regex.Replace(code, "namespace $1 " + Environment.NewLine + "{");

            // Add closing bracket to the end of file
            return newCode + Environment.NewLine + "}";
        }
    }
}