using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    public class RemoveCheckedExceptions
    {
        public string Apply(string code)
        {
            var regex = new Regex(@"throws([a-zA-Z0-9\.,\s]+)", RegexOptions.Multiline);
            return regex.Replace(code, string.Empty);
        }
    }
}