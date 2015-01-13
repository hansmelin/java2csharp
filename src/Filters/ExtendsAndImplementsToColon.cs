using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    public class ExtendsAndImplementsToColon : IFilter
    {
        /// <summary>
        ///     Converts java extends and implements keywords to C# colon (:)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string Apply(string code)
        {
            var regex = new Regex(@"\s(extends)\s(.*)\s(implements)\s", RegexOptions.Multiline);
            string newCode = regex.Replace(code, " : $2, ");

            newCode = newCode.ConvertKeyword("extends", ":");
            newCode = newCode.ConvertKeyword("implements", ":");
            return newCode;
        }
    }
}