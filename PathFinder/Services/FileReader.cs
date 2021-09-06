using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using PathFinder.Configuration;
using PathFinder.Interfaces;

namespace PathFinder.Services
{
    /// <summary>
    /// File reader that takes a file name, retrieves the file and returns a list of parsed words
    /// </summary>
    public class FileReader : IFileReader
    {
        private readonly IOptions<FileReaderConfiguration> _fileReaderSettings;
        
        public FileReader(IOptions<FileReaderConfiguration> fileReaderSettings)
        {
            _fileReaderSettings = fileReaderSettings;
        }
        public IEnumerable<string> Read(string dictionaryFile)
        {
            var words = File.ReadAllLines(dictionaryFile.ToString()).ToList();

            // TODO: put tests around this
            return words.Where(x => x.Length == int.Parse(_fileReaderSettings.Value.MaxWordLength)).Select(x => x.ToLowerInvariant()).Distinct();
        }
    }
}