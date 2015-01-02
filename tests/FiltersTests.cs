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
            var addUsings = new AddUsings("System", "System.Collections.Generic");

            string java = ReadSample("Sample2.java");
            string csharp = addUsings.Apply(java);
            Assert.Equal(ReadSample("Sample2.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertPackageToNamespace()
        {
            var packageToNamespace = new PackageToNamespace();

            string java = ReadSample("Sample3.java");
            string csharp = packageToNamespace.Apply(java);
            Assert.Equal(ReadSample("Sample3.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldRemoveCheckedExceptions()
        {
            var removeCheckedExceptions = new RemoveCheckedExceptions();

            string java = ReadSample("Sample4.java");
            string csharp = removeCheckedExceptions.Apply(java);
            Assert.Equal(ReadSample("Sample4.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        private string ReadSample(string sample)
        {
            return File.ReadAllText(@"Samples\" + sample);
        }
    }
}