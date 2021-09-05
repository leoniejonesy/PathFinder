using System.Collections.Generic;

namespace PathFinder.Interfaces
{
    public interface IPathFinder
    {
        List<string> FindPath(Dictionary<string, List<string>> data, string startValue, string endValue);
    }
}