using PathFinder.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PathFinder.Configuration;
using PathFinder.Services;

namespace PathFinder
{
    /// <summary>
    /// Path finder designed to read a file and parse a list of words
    /// then find a path from a given start word and end word and write to file
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<PathFinderHostedService>();
                    services.AddScoped<IFileReader, FileReader>();
                    services.AddScoped<IDataParser, DataParser>();
                    services.AddScoped<IPathFinder, BfsShortestPathFinder>();
                    services.AddScoped<IFileWriter, FileWriter>();
                    
                    services.AddOptions<FileReaderConfiguration>().Bind(hostContext.Configuration.GetSection("FileReaderConfig"));
                })
                .RunConsoleAsync();
        }
    }
}