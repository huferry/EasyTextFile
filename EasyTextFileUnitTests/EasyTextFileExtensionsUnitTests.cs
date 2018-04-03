using System.IO;
using System.Reflection;
using EasyTextFile;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyTextFileUnitTests
{
    [TestClass]
    public class EasyTextFileExtensionsUnitTests
    {
        [TestMethod]
        public void SaveToFile_WithTextContent_ShouldCreateFile()
        {
            // Arrange.
            // Act.
            "Hello, World!\nGood Morning!".SaveToFile("test03.txt");

            // Assert.
            "test03.txt".LoadFile().Should().BeEquivalentTo(
                "Hello, World!",
                "Good Morning!");
        }

        [TestMethod]
        public void SaveToFile_WithAnyText_ShouldCreateFile()
        {
            // Arrange.
            var text = new[]
            {
                "Hello, World!",
                "How are you?"
            };

            var expected = string.Join("\n", text);

            // Act.
            text.SaveToFile("test01.txt");

            // Assert.
            using (var reader = new StreamReader("test01.txt"))
            {
                reader.ReadToEnd().Should().Be(expected);
            }
        }

        [TestMethod]
        public void ToLines_WithStringContainingCR_ShouldReturnInArray()
        {
            // Arrange.
            var text = "Easy come,\neasy go.";

            // Act.
            var actual = text.ToLines();

            // Assert.
            actual.Should().BeEquivalentTo("Easy come,", "easy go.");
        }

        [TestMethod]
        public void ToText_WithAnyStringArray_ReturnsCRSeparatedString()
        {
            // Arrange.
            var lines = new[]
            {
                "Roses are red,",
                "violets are blue."
            };

            // Act.
            var actual = lines.ToText();

            // Assert.
            actual.Should().Be("Roses are red,\nviolets are blue.");
        }

        [TestMethod]
        public void LoadFromFile_WithAnyTextFile_ShouldLoadFile()
        {
            // Arrange.
            var expected = new[]
            {
                "I see,",
                "I come,",
                "I conquer"
            };

            using (var writer = new StreamWriter("test02.txt"))
            {
                writer.Write(string.Join("\n", expected));
            }

            // Act.
            var actual = "test02.txt".LoadFile();

            // Assert.
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void LoadFromEmbeddedResource_WithFileName_ShouldLoadText()
        {
            // Arrange.
            string expected;
            using (var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("EasyTextFileUnitTests.example.txt"))
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(stream))
                {
                    expected = reader.ReadToEnd();
                }
            }

            // Act.
            var actual = "example.txt".LoadFromEmbeddedResource();

            // Assert.
            actual.Should().Be(expected);
        }
    }
}