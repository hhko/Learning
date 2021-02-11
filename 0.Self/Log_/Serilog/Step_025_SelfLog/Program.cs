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
            /*
            <add key="serilog:minimum-level" value="Verbose" />
            <add key="serilog:enrich:with-property:AppVersion" value="1.6.0" />
            <add key="serilog:write-to:File.path" value="./Logs/LogFile.json" />
            <add key="serilog:write-to:File.formatter" value="Serilog.Formatting.Json.JsonFormatter, Serilog, Version=2.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10" />
            <add key="serilog:write-to:Console.formatter" value="Serilog.Formatting.Json.JsonFormatter, Serilog, Version=2.0.0.0, Culture=neutral, PublicKeyToken=24c2f752a8e58a10" />
            <add key="serilog:using:File" value="Serilog.Sinks.File" />
            <add key="serilog:using:Console" value="Serilog.Sinks.Console" />
            */
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
