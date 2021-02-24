using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Diagnostics;
using System.IO;

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
            // SelfLog.Enable을 여러번 호출하면 마지막 호출만 적용된다.
            //

            //
            // Debugging and Diagnostics
            // https://github.com/serilog/serilog/wiki/Debugging-and-Diagnostics
            // 
            // public static void Enable(TextWriter output);
            // public static void Enable(Action<string> output);
            //
            Serilog.Debugging.SelfLog.Enable(Console.Error);
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            //
            // Thread로부터 안전한 TextWriter을 생성한다.
            //
            Serilog.Debugging.SelfLog.Enable(
                TextWriter.Synchronized(
                    File.CreateText("./Log/Serilog.txt")));

            Log.Information("Hello World!");

            Log.CloseAndFlush();
        }
    }
}
