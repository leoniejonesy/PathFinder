using System.Collections.Generic;
using System.IO;
using PathFinder.Interfaces;

namespace PathFinder
{
    public class FileWriter : IFileWriter
    {
        public void Write(List<string> path, string resultFilePath)
        {
            File.WriteAllLines(resultFilePath, path);
        }
    }
}