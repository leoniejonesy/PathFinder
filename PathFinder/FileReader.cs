using System.Collections.Generic;
using System.IO;
using System.Linq;
using PathFinder.Interfaces;

namespace PathFinder
{
    public class FileReader : IFileReader
    {
        private const int MaxWordLength = 4;

        public IEnumerable<string> Read(string dictionaryFile)
        {
            var words = File.ReadAllLines(dictionaryFile.ToString()).ToList();

            // TODO: put tests around this
            return words.Where(x => x.Length == MaxWordLength).Select(x => x.ToLowerInvariant()).Distinct();
        }
    }
}