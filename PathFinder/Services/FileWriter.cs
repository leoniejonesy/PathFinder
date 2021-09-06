using System.Collections.Generic;
using System.IO;
using PathFinder.Interfaces;

namespace PathFinder.Services
{
    /// <summary>
    /// File writer that takes the path and a file name and writes the path to file
    /// </summary>
    public class FileWriter : IFileWriter
    {
        public void Write(List<string> path, string resultFilePath)
        {
            File.WriteAllLines(resultFilePath, path);
        }
    }
}