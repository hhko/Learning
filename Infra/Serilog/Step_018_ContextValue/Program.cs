using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_018_ContextValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                            .CreateLogger();

            // - [x] public static ILogger ForContext<TSource>();
            //          키 : SourceContext
            //          값 : 로그 출력 클래스
            // - [x] public static ILogger ForContext(
            //          string propertyName, 
            //          object value, 
            //          bool destructureObjects = false);
            // - [ ] public static ILogger ForContext(ILogEventEnricher enricher);
            // - [ ] public static ILogger ForContext(Type source);

            // [10:03:49 INF] Hello World
            //
            // {
            //     "Timestamp": "2021-02-05T14:45:18.0342383+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "MyKey": "2021"                                  // 로그 키(MyKey)와 값(2021)
            //     }
            // }
            ILogger contextLogger = Log.ForContext("MyKey", "2021");
            contextLogger.Information("Hello World");

            // [10:03:49 INF] Hello World from Non-Context
            //
            // {
            //     "Timestamp": "2021-02-05T10:07:32.1467764+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World2"
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
            // [10:03:49 INF] Hello Foo
            //
            // {
            //     "Timestamp": "2021-02-05T14:45:18.0508461+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "MyKey": "2021"                                  // 로그 키(MyKey)와 값(2021)
            //     }
            // }
            ILogger contextLogger = Log.ForContext("MyKey", "2021");
            contextLogger.Information("Hello Foo");
        }
    }
}
