using System.Collections.Generic;
using System.Linq;
using PathFinder.Interfaces;

namespace PathFinder
{
    public class BfsShortestPathFinder : IPathFinder
    {
        public List<string> FindPath(Dictionary<string, List<string>> data, string startValue, string endValue)
        {
            var visitedNodes = new Dictionary<string, string>();

            var queue = new Queue<string>();
            queue.Enqueue(startValue);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var linkedNode in data[node].Where(x => !visitedNodes.ContainsKey(x)))
                {
                    visitedNodes.Add(linkedNode, node);
                    queue.Enqueue(linkedNode);
                }
            }

            var path = new List<string>();

            var current = endValue;
            while (!current.Equals(startValue))
            {
                path.Add(current);
                current = visitedNodes[current];
            };

            path.Add(startValue);
            path.Reverse();

            return path;
        }
    }
}