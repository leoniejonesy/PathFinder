using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PathFinder.Interfaces;
using System.CommandLine;
using System.CommandLine.Invocation;

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
            ParseArguments();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private int ParseArguments()
        {
            var args = Environment.GetCommandLineArgs();

            var rootCommand = new RootCommand
            {
                new Option<string>(
                    "--DictionaryFile",
                    description: "Specify the Dictionary File"),
                new Option<string>(
                    "--StartWord",
                    "Specify the Start Word\n"),
                new Option<string>(
                    "--EndWord",
                    "Specify the End Word\n"),
                new Option<string>(
                    "--ResultFile",
                    "Specify the Result File")
            };

            rootCommand.Description = "Console App to find the path between two words given reference to a file containing a list of words";
            rootCommand.Handler = CommandHandler.Create<string, string, string, string>(Execute);
            return rootCommand.InvokeAsync(args).Result;
        }

        private void Execute(string dictionaryFile, string startWord, string endWord, string resultFile)
        {
            var words = _fileReader.Read(dictionaryFile);
            var data = _dataParser.ParseData(words);
            var path = _pathFinder.FindPath(data, startWord, endWord);
            _fileWriter.Write(path, resultFile);
        }
    }
}