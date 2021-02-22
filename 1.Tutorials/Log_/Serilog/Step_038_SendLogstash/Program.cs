using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using System;
using System.Threading;

namespace Step_038_SendLogstash
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Http(requestUri: "http://192.168.70.23:7701")
                            .Enrich.WithProperty("AppVersion", "1.6.0")
                            //.WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.Console(formatter: new ElasticsearchJsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                            .CreateLogger();

            for (int i = 0; i < 10; i++)
            {
                Log.Information("Hello World > {Number}", i);

                Thread.Sleep(1000);
            }

            Log.CloseAndFlush();
        }
    }
}
