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
                    // ConfigurationBuilder : Microsoft.Extensions.Configuration
            var configuration = new ConfigurationBuilder()

                    // SetBasePath : Microsoft.Extensions.Configuration.FileExtensions
                    .SetBasePath(Directory.GetCurrentDirectory())

                    // AddJsonFile : Microsoft.Extensions.Configuration.Json
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            //
            // 코드 Serilog 환경 설정
            //
            // Log.Logger = new LoggerConfiguration()
            //                 .MinimumLevel.Verbose()
            //                 .Enrich.WithProperty("AppVersion", "1.6.0")
            //                 .WriteTo.Console(formatter: new JsonFormatter())
            //                 .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
            //                 .CreateLogger();
            //
            //
            // Json 파일 Serilog 환경 설정
            //
            // {
            //   "Serilog": {
            //     "Using": [ "Serilog.Sinks.File", "Serilog.Sinks.Console" ],
            //     "MinimumLevel": "Verbose",             <- .MinimumLevel.Verbose()
            //     "WriteTo": [
            //       {
            //         "Name": "File",                    <- .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
            //         "Args": {
            //           "path": "./Logs/LogFile.json",
            //           "formatter": "Serilog.Formatting.Json.JsonFormatter, Serilog"
            //         }
            //       },
            //       {
            //         "Name": "Console",                 <- .WriteTo.Console(formatter: new JsonFormatter())
            //         "Args": { "formatter": "Serilog.Formatting.Json.JsonFormatter, Serilog" }
            //       }
            //     ],
            //     "Properties": {                        <- .Enrich.WithProperty("AppVersion", "1.6.0")
            //       "AppVersion": "1.6.0"
            //     }
            //   }
            // }



            // {
            //     "Timestamp": "2021-02-10T10:59:50.3658509+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello, world!",
            //     "Properties": {
            //         "AppVersion": "1.6.0"
            //     }
            // }
            Log.Information("Hello, world!");

            Log.CloseAndFlush();
        }
    }
}
