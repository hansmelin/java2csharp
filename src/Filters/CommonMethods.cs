using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    public class CommonMethods : IFilter
    {
        public string Apply(string code)
        {
            code = code.Replace(".trim()", ".Trim()");
            code = code.Replace(".toLowerCase()", ".ToLower()");
            code = code.Replace(".toUpperCase()", ".ToUpper()");
            code = code.Replace(".length()", ".Length");
            code = code.Replace(".substring(", ".Substring(");
            code = code.Replace(".replace(", ".Replace(");
            code = code.Replace(".equals(", ".Equals(");
            code = code.Replace(".add(", ".Add(");
            code = code.Replace(".contains(", ".Contains(");
            code = code.Replace(".startsWith(", ".StartsWith(");
            code = code.Replace(".append(", ".Append(");
            code = code.Replace(".toString(", ".ToString(");

            var regex2 = new Regex(@"\.charAt\((\w)\)", RegexOptions.Multiline);
            code = regex2.Replace(code, "[$1]");

            return code;
        }
    }
}