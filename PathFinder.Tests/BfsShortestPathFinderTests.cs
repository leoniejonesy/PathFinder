using System.Collections.Generic;
using NUnit.Framework;
using PathFinder.Services;

namespace PathFinder.Tests
{
    [TestFixture]
    public class BfsShortestPathFinderTests
    {
        private Dictionary<string, List<string>> _values;
        
        [SetUp]
        public void Setup()
        {
            var words = new List<string>
            {
                "Spin",
                "Spit",
                "Spat",
                "Spot",
                "Span"
            };

            _values = new DataParser().ParseData(words);
        }
        
        [Test]
        public void FindPath_WithDataAndStartAndEndWords_ShouldReturnShortestPath()
        {
            var pathFinder = new BfsShortestPathFinder();

            var result = pathFinder.FindPath(_values, "Spin", "Spot");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("Spin"));
            Assert.That(result[2], Is.EqualTo("Spot"));
        }

        [Test]
        public void FindPath_WithDataThatDoesNotContainStartWord_ShouldThrowException()
        {
            void Act()
            {
                var pathFinder = new BfsShortestPathFinder();

                var result = pathFinder.FindPath(_values, "Sway", "Spot");
            }
            
            Assert.That(Act, Throws.ArgumentException.With.Message.Contains("File does not contain specified start word"));
        }

        [Test]
        public void FindPath_WithDataThatDoesNotContainEndWord_ShouldThrowException()
        {
            void Act()
            {
                var pathFinder = new BfsShortestPathFinder();
                
                pathFinder.FindPath(_values, "Spin", "Sway");
            }

            Assert.That(Act, Throws.ArgumentException.With.Message.Contains("File does not contain specified end word"));
        }
    }
}