using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Java2csharp.Filters
{
    /// <summary>
    ///     Targets e.g. import java.lang.annotation.Retention;
    ///     Converts the target to e.g. using java.lang.annotation and moves it to the beginning of the file
    /// </summary>
    /// <returns></returns>
    public class ImportsToUsings
    {
        public string Apply(string code)
        {
            // Find all imports
            var regex = new Regex(@"^import.+$", RegexOptions.Multiline);
            IList<string> usings = new List<string>();

            foreach (Match import in regex.Matches(code))
            {
                string[] strings = import.Value.Split('.');
                strings[0] = strings[0].Replace("import ", "using ");

                var usingDirective = new StringBuilder();

                int upper = strings.Length - 1;
                for (int i = 0; i < upper; i++)
                {
                    usingDirective.Append(strings[i]);

                    if (i < upper - 1)
                    {
                        usingDirective.Append(".");
                    }
                    else
                    {
                        usingDirective.Append(";");
                    }
                }

                // in Java you import every class, in C# you only import the namespace
                if (!usings.Contains(usingDirective.ToString()))
                {
                    usings.Add(usingDirective.ToString());
                }
            }

            // Remove all imports           
            string textWithNoImports = Regex.Replace(code, @"import.+\n", string.Empty);

            // Put the converted usings first in file
            var result = new StringBuilder();
            foreach (string @using in usings)
            {
                result.Append(@using);
                result.AppendLine();
            }
            result.AppendLine();

            // Add the rest of the code after the new usings
            result.Append(textWithNoImports);

            return result.ToString();
        }
    }
}