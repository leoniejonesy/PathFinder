using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PathFinder.Interfaces;

namespace PathFinder
{
    internal class PathFinderHostedService : IHostedService
    {
        private readonly IFileReader _fileReader;
        private readonly IDataParser _dataParser;
        private readonly IPathFinder _pathFinder;
        private readonly IFileWriter _fileWriter;

        public PathFinderHostedService(IFileReader fileReader, IDataParser dataParser, IPathFinder pathFinder, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _dataParser = dataParser;
            _pathFinder = pathFinder;
            _fileWriter = fileWriter;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Enter Dictionary File Name:");
            var dictionaryFile = Console.ReadLine();

            Console.WriteLine("Enter Start Word:");
            var startWord = Console.ReadLine();

            Console.WriteLine("Enter End Word:");
            var endWord = Console.ReadLine();

            Console.WriteLine("Enter Result File Name:");
            var resultFile = Console.ReadLine();
            
            var words = _fileReader.Read(dictionaryFile);
            var data = _dataParser.ParseData(words, startWord, endWord);
            var path = _pathFinder.FindPath(data, startWord, endWord);
            _fileWriter.Write(path, resultFile);

            return default;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}