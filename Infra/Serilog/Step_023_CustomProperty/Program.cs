using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_023_CustomProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .Enrich.WithProperty("AppVersion", "1.6.0")

                            //
                            // 사용자 정의 전역 속성
                            // https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/
                            //
                            //.Enrich.With(new AppEnricher())
                            .Enrich.WithApp()

                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                            .CreateLogger();

            // {
            //     "Timestamp": "2021-02-05T15:18:12.3022568+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "SourceContext": "Step_023_CustomProperty.Program",
            //         "AppVersion": "1.6.0",
            //         "ApplicationName": "Step_023_CustomProperty",            // AppEnricher
            //         "ApplicationVersion": "1.0.0.0"                          // AppEnricher
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Program>();
            contextLogger.Information("Hello World");

            // {
            //     "Timestamp": "2021-02-05T15:18:12.3216003+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World from Non-Context",
            //     "Properties": {
            //         "AppVersion": "1.6.0",
            //         "ApplicationName": "Step_023_CustomProperty",            // AppEnricher
            //         "ApplicationVersion": "1.0.0.0"                          // AppEnricher
            //     }
            // }
            Log.Information("Hello World from Non-Context");

            Foo foo = new Foo();
            foo.DoSomething();
        }
    }

    public class Foo
    {
        public void DoSomething()
        {
            // {
            //     "Timestamp": "2021-02-05T15:18:12.3219992+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "SourceContext": "Step_023_CustomProperty.Foo",
            //         "AppVersion": "1.6.0",
            //         "ApplicationName": "Step_023_CustomProperty",            // AppEnricher
            //         "ApplicationVersion": "1.0.0.0"                          // AppEnricher
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Foo>();
            contextLogger.Information("Hello Foo");
        }
    }
}



