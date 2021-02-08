using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Step_025_JsonConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
                    //
                    // Microsoft.Extensions.Configuration
                    //
            var configuration = new ConfigurationBuilder()

                    //
                    // Microsoft.Extensions.Configuration.FileExtensions
                    //
                    .SetBasePath(Directory.GetCurrentDirectory())

                    //
                    // Microsoft.Extensions.Configuration.Json
                    //
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            // Serilog.Settings.Configuration   : JSON
            // Serilog.Settings.AppSettings     : XML
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Information("Hello, world!");

            Log.CloseAndFlush();
        }
    }
}
