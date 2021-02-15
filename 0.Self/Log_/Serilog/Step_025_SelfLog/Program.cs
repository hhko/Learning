using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Diagnostics;

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
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new CompactJsonFormatter())
                            .CreateLogger();

            //
            // public static void Enable(TextWriter output);
            // public static void Enable(Action<string> output);
            //
            Serilog.Debugging.SelfLog.Enable(Console.Error);
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            Log.Information("Hello World!");

            Log.CloseAndFlush();
        }
    }
}
