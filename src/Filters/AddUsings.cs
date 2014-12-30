using System.Collections.Generic;
using System.Text;

namespace Java2csharp.Filters
{
    /// <summary>
    /// Add usings to a class that does not exist in the java file, e.g. using System;
    /// </summary>
    public class AddUsings
    {
        public string Apply(string code, IList<string> usings)
        {            
            // Put the usings first in file
            var result = new StringBuilder();
            foreach (string @using in usings)
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