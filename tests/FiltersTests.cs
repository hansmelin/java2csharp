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
        public void ShouldAddDefaultUsings()
        {
            IList<string> defaultUsings = new List<string>();
            // Append default usings for .net
            defaultUsings.Add("using System;");
            defaultUsings.Add("using System.Collections.Generic;");

            // Append default usings for ikvm
            defaultUsings.Add("using java.lang;");
            defaultUsings.Add("using Object = java.lang.Object;");

            var addDefaultUsings = new AddDefaultUsings();

            string java = ReadSample("Sample2.java");
            string csharp = addDefaultUsings.Apply(java, defaultUsings);
            Assert.Equal(ReadSample("Sample2.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        private string ReadSample(string sample)
        {
            return File.ReadAllText(@"Samples\" + sample);
        }
    }
}