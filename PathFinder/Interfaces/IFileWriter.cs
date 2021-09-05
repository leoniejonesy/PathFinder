using System.Collections.Generic;

namespace PathFinder.Interfaces
{
    public interface IFileWriter
    {
        void Write(List<string> path, string resultFilePath);
    }
}