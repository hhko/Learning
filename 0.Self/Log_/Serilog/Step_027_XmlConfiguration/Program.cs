using Serilog;
using System;

namespace Step_026_XmlConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
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
            // Xml 파일 Serilog 환경 설정
            //
            // <appSettings>
            // 	  <add key="serilog:minimum-level" value="Verbose" />                           <- .MinimumLevel.Verbose()
            // 	  <add key="serilog:enrich:with-property:AppVersion" value="1.6.0" />           <- .Enrich.WithProperty("AppVersion", "1.6.0")
            // 	  <add key="serilog:write-to:File.path" value="./Logs/LogFile.json" />          <- .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
            // 	  <add key="serilog:write-to:File.formatter" value="Serilog.Formatting.Json.JsonFormatter, Serilog" />
            // 	  <add key="serilog:write-to:Console.formatter" value="Serilog.Formatting.Json.JsonFormatter, Serilog" />  <- .WriteTo.Console(formatter: new JsonFormatter())
            // 	  <add key="serilog:using:File" value="Serilog.Sinks.File" />
            // 	  <add key="serilog:using:Console" value="Serilog.Sinks.Console" />
            // </appSettings>
            //
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
