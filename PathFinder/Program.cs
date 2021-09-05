using System;
using System.Collections.Generic;
using PathFinder.Interfaces;

namespace PathFinder
{
    class Program
    {
        private static IFileReader _fileReader;
        private static IDataParser _dataParser;
        private static IPathFinder _pathFinder;
        private static IFileWriter _fileWriter;

        static void Main(string[] args)
        {
            _fileReader = new FileReader();
            _dataParser = new DataParser();

            string dictionaryFile, startWord, endWord, resultFile;

            Console.WriteLine("Enter Dictionary File Name:");
            dictionaryFile = Console.ReadLine();

            Console.WriteLine("Enter Start Word:");
            startWord = Console.ReadLine();

            Console.WriteLine("Enter End Word:");
            endWord = Console.ReadLine();

            Console.WriteLine("Enter Result File Name:");
            resultFile = Console.ReadLine();

            IEnumerable<string> words =_fileReader.Read(dictionaryFile);


            FindPath(dictionaryFile, startWord, endWord, new FileReader(), new DataParser());
        }

        private static void FindPath(string dictionaryFile, string startWord, string endWord, IFileReader fileReader, IDataParser dataParser)
        {
            var words = fileReader.Read(dictionaryFile);
            var data = dataParser.ParseData(words, startWord, endWord);
        }
    }
}