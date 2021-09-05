using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PathFinder.Tests
{
    [TestFixture]
    public class DataParserTests
    {
        private List<string> _values;
        
        [SetUp]
        public void Setup()
        {   
            _values = new List<string> {"Spin", "Spit", "Spat", "Spot", "Span", "Soon", "Swan"};
        }
        
        [Test]
        public void ParseData_WithListOfValues_ShouldReturnDictionaryWithLinkedValues()
        {
            var values = new List<string> {"Spin", "Spit", "Spat", "Spot", "Span", "Soon", "Swan"};
            
            var sut = new DataParser();

            var result = sut.ParseData(_values, "Test", "Test");
            
            Assert.That(result[_values[0]].Count(), Is.EqualTo(2));
            Assert.That(result[_values[1]].Count(), Is.EqualTo(3));
            Assert.That(result[_values[2]].Count(), Is.EqualTo(3));
            Assert.That(result[_values[3]].Count(), Is.EqualTo(2));
            Assert.That(result[_values[4]].Count(), Is.EqualTo(3));
            Assert.That(result[_values[5]].Count(), Is.EqualTo(0));
            Assert.That(result[_values[5]].Count(), Is.EqualTo(0));
        }

        [Test]
        public void ParseData_WithListOfValues_ShouldStopAddingToDictionaryIfStartWordIsLinkedToEndWord()
        {
            var sut = new DataParser();

            var result = sut.ParseData(_values, "Spin", "Span");
            
            Assert.That(result.Count(), Is.EqualTo(1));
        }
    }
}