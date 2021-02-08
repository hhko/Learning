using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_024_SelfLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .Enrich.WithProperty("AppVersion", "1.6.0")
                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                            .CreateLogger();

            //
            // public static void Enable(TextWriter output);
            // public static void Enable(Action<string> output);
            //
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            Log.Information("Hello World!");

            Log.CloseAndFlush();
        }
    }
}
