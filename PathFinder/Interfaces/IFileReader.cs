using System.Collections.Generic;

namespace PathFinder.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<string> Read(string dictionaryFile);
    }
}