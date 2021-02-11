using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_022_WithProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()

                            //
                            // 전역 속성
                            //
                            .Enrich.WithProperty("AppVersion", "1.6.0")

                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                            .CreateLogger();

            // {
            //     "Timestamp": "2021-02-05T15:14:32.3149354+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "SourceContext": "Step_022_WithProperty.Program",
            //         "AppVersion": "1.6.0"                                // 전역 속성
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Program>();
            contextLogger.Information("Hello World");

            // {
            //     "Timestamp": "2021-02-05T15:14:32.3316773+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World from Non-Context",
            //     "Properties": {
            //         "AppVersion": "1.6.0"                                // 전역 속성
            //     }
            // }
            Log.Information("Hello World from Non-Context");

            Foo foo = new Foo();
            foo.DoSomething();

            Log.CloseAndFlush();
        }
    }

    public class Foo
    {
        public void DoSomething()
        {
            // {
            //     "Timestamp": "2021-02-05T15:14:32.3321114+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "SourceContext": "Step_022_WithProperty.Foo",
            //         "AppVersion": "1.6.0"                                // 전역 속성
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Foo>();
            contextLogger.Information("Hello Foo");
        }
    }
}