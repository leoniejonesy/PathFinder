using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using PathFinder.Configuration;
using PathFinder.Services;

namespace PathFinder.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        private readonly string _testDataFilePath = string.Concat(TestContext.CurrentContext.TestDirectory, "\\TestData\\words-english-test-data.txt");
        private FileReader _fileReader;

        [SetUp]
        public void Setup()
        {
            var options = new FileReaderConfiguration
            {
                MaxWordLength = "4"
            };
            _fileReader = new FileReader(Options.Create(options));
        }
        
        [Test]
        public void Read_WithWordsInVaryingCases_ShouldReturnAllWordsInLowercase()
        {
            var result = _fileReader.Read(_testDataFilePath);

            Assert.That(result.Count(x => Enumerable.Any(x, char.IsUpper)), Is.EqualTo(0));
        }

        [Test]
        public void Read_WithWordsLongerThanFourCharacters_ShouldReturnWordsWithFourCharactersOnly()
        {
            var result = _fileReader.Read(_testDataFilePath);
            
            Assert.That(result.Select(x => x.Count()).Any(x => x > 4), Is.False);
        }

        [Test]
        public void Read_WithDuplicateWords_ShouldReturnDistinctWords()
        {
            var result = _fileReader.Read(_testDataFilePath);
            
            Assert.That(result.Count(), Is.EqualTo(5));
        }

        [Test]
        public void Read_WithFilePathOfFileThatDoNotExist_ShouldThrowException()
        {
            void Act()
            {
                _fileReader.Read("invalid-file-name");
            }

            Assert.That(Act, Throws.InstanceOf<FileNotFoundException>().With.Message.Contains("File not found"));
        }
    }
}