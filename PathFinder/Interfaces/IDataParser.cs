using System.Collections.Generic;

namespace PathFinder.Interfaces
{
    public interface IDataParser
    {
        Dictionary<string, List<string>> ParseData(IEnumerable<string> values);
    }
}