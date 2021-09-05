using System;
using System.Collections.Generic;
using PathFinder.Interfaces;

namespace PathFinder
{
    class Program
    {
        private static string DictionaryFile;
        private static string StartWord;
        private static string EndWord;
        private static string ResultFile;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Dictionary File Name:");
            DictionaryFile = Console.ReadLine();

            Console.WriteLine("Enter Start Word:");
            StartWord = Console.ReadLine();

            Console.WriteLine("Enter End Word:");
            EndWord = Console.ReadLine();

            Console.WriteLine("Enter Result File Name:");
            ResultFile = Console.ReadLine();

            FindPath(new FileReader(), new DataParser(), new BfsShortestPathFinder(), new FileWriter());
        }

        private static void FindPath(IFileReader fileReader, IDataParser dataParser, IPathFinder pathFinder, IFileWriter fileWriter)
        {
            var words = fileReader.Read(DictionaryFile);
            var data = dataParser.ParseData(words, StartWord, EndWord);
            var path = pathFinder.FindPath(data, StartWord, EndWord);
            fileWriter.Write(path, ResultFile);
        }
    }
}