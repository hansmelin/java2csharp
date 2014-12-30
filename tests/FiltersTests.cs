using System.Collections.Generic;
using System.IO;
using Java2csharp.Filters;
using Xunit;

namespace Java2csharp.Tests
{
    public class FiltersTests
    {
        [Fact]
        public void ShouldReplaceImportsWithUsings()
        {
            var importsToUsings = new ImportsToUsings();

            string java = ReadSample("Sample1.java");            
            string csharp = importsToUsings.Apply(java);
            Assert.Equal(ReadSample("Sample1.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldAddUsings()
        {
            IList<string> usings = new List<string>();
            // Add default usings for .net
            usings.Add("using System;");
            usings.Add("using System.Collections.Generic;");

            // Add default usings for ikvm
            usings.Add("using java.lang;");
            usings.Add("using Object = java.lang.Object;");

            var addUsings = new AddUsings();

            string java = ReadSample("Sample2.java");
            string csharp = addUsings.Apply(java, usings);
            Assert.Equal(ReadSample("Sample2.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        private string ReadSample(string sample)
        {
            return File.ReadAllText(@"Samples\" + sample);
        }
    }
}