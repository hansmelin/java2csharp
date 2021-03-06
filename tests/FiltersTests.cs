﻿using System.IO;
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

        [Fact]
        public void ShouldConvertExtendsAndImplementsToColon()
        {
            var extendsAndImplementsToColon = new ExtendsAndImplementsToColon();

            string java = ReadSample("Sample5.java");
            string csharp = extendsAndImplementsToColon.Apply(java);
            Assert.Equal(ReadSample("Sample5.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertFinalToReadOnly()
        {
            var finalToReadOnly = new FinalToReadOnly();

            string java = ReadSample("Sample6.java");
            string csharp = finalToReadOnly.Apply(java);
            Assert.Equal(ReadSample("Sample6.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertSimpleAnnotationToAttribute()
        {
            var simpleAnnotationToAttribute = new SimpleAnnotationToAttribute();

            string java = ReadSample("Sample7.java");
            string csharp = simpleAnnotationToAttribute.Apply(java);
            Assert.Equal(ReadSample("Sample7.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertPrimitiveTypes()
        {
            var primitiveTypes = new PrimitiveTypes();

            string java = ReadSample("Sample8.java");
            string csharp = primitiveTypes.Apply(java);
            Assert.Equal(ReadSample("Sample8.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertCommonMethods()
        {
            var commonMethods = new CommonMethods();

            string java = ReadSample("Sample9.java");
            string csharp = commonMethods.Apply(java);
            Assert.Equal(ReadSample("Sample9.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        [Fact]
        public void ShouldConvertForeachLoop()
        {
            var forEachLoop = new ForEachLoop();

            string java = ReadSample("Sample10.java");
            string csharp = forEachLoop.Apply(java);
            Assert.Equal(ReadSample("Sample10.csharp"), csharp, new StringCompIgnoreWhiteSpace());
        }

        private string ReadSample(string sample)
        {
            return File.ReadAllText(@"Samples\" + sample);
        }
    }
}