using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    public class ForEachLoop : IFilter
    {
        public string Apply(string code)
        {
            var regex = new Regex(@"^(\s*)for(\s*)(\(.+):", RegexOptions.Multiline);
            code = regex.Replace(code, "$1foreach$2$3in");
            return code;
        }
    }
}