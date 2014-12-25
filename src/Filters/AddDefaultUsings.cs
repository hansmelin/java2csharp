using System.Collections.Generic;
using System.Text;

namespace Java2csharp.Filters
{
    public class AddDefaultUsings
    {
        public string Apply(string code, IList<string> defaultUsings)
        {            
            // Put the usings first in file
            var result = new StringBuilder();
            foreach (string @using in defaultUsings)
            {
                result.Append(@using);
                result.AppendLine();
            }

            result.AppendLine();

            // Add the rest of the code after the new usings
            result.Append(code);

            return result.ToString();
        }
    }
}