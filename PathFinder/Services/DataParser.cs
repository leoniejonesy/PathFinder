using System.Collections.Generic;
using System.Linq;
using PathFinder.Interfaces;

namespace PathFinder.Services
{
    /// <summary>
    /// Data parser that takes a list of words and returns an adjacency list 
    /// </summary>
    public class DataParser : IDataParser
    {
        private List<string> _values;

        public Dictionary<string, List<string>> ParseData(IEnumerable<string> values)
        {
            _values = values.ToList();

            var nodeList = new Dictionary<string, List<string>>();

            foreach (var value1 in _values)
            {
                var linkedValues = new List<string>();
                
                foreach (var value2 in _values)
                {
                    if (OneCharacterDifference(value1, value2))
                    {
                        linkedValues.Add(value2);
                    }
                }
                
                nodeList.Add(value1, linkedValues);
            }

            return nodeList;
        }

        private bool OneCharacterDifference(string str1, string str2)
        {
            int numberOfDifferences = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                if (str2[i] != str1[i])
                    numberOfDifferences++;
            }

            return numberOfDifferences == 1;
        }
    }
}