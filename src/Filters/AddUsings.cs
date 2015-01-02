using System.Text;

namespace Java2csharp.Filters
{
    /// <summary>
    ///     Add usings to a class that does not exist in the java file, e.g. using System.Text;
    /// </summary>
    public class AddUsings : IFilter
    {
        private readonly string[] namespaces;

        public AddUsings(params string[] namespaces)
        {
            this.namespaces = namespaces;
        }

        public string Apply(string code)
        {
            if (namespaces == null || namespaces.Length == 0)
            {
                return code;
            }

            // Put the usings first in file
            var result = new StringBuilder();
            foreach (string @namespace in namespaces)
            {
                result.Append("using ");
                result.Append(@namespace);
                result.AppendLine(";");
            }

            result.AppendLine();

            // Add the rest of the code after the new usings
            result.Append(code);

            return result.ToString();
        }
    }
}