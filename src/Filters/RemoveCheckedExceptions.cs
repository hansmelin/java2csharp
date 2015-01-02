using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    /// <summary>
    /// TODO: Add exception tags as an option instead of just removing them
    /// http://msdn.microsoft.com/en-us/library/w1htk11d.aspx
    /// </summary>
    public class RemoveCheckedExceptions : IFilter
    {
        public string Apply(string code)
        {
            var regex = new Regex(@"throws([a-zA-Z0-9\.,\s]+)", RegexOptions.Multiline);
            return regex.Replace(code, string.Empty);
        }
    }
}