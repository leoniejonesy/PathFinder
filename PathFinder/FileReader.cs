using System.Collections.Generic;
using System.IO;
using System.Linq;
using PathFinder.Interfaces;

namespace PathFinder
{
    public class FileReader : IFileReader
    {
        private const int MAX_WORD_LENGTH = 4;

        public IEnumerable<string> Read(string dictionaryFile)
        {
            var words = File.ReadAllLines(dictionaryFile.ToString()).ToList();

            return words.Where(x => x.Length == MAX_WORD_LENGTH);
        }
    }
}