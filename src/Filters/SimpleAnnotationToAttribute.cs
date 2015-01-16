using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    /// <summary>
    /// Converts e.g. @Test => [Test] OR @Test(test="test") => [Test(test="test")]
    /// </summary>
    /// <returns></returns>
    public class SimpleAnnotationToAttribute : IFilter
    {
        public string Apply(string code)
        {
            var regex = new Regex(@"(^\s*)@(\w+)(\(.+\))?(\s*)$$", RegexOptions.Multiline);
            return regex.Replace(code, "$1[$2$3]$4");
        }
    }
}