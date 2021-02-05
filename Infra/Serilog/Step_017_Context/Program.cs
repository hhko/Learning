using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_017_Context
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
            // - [ ] public static ILogger ForContext(
            //          string propertyName, 
            //          object value, 
            //          bool destructureObjects = false);
            // - [ ] public static ILogger ForContext(ILogEventEnricher enricher);
            // - [ ] public static ILogger ForContext(Type source);

            // [10:03:49 INF] Hello World
            // 
            // {
            //     "Timestamp": "2021-02-05T10:04:29.5128059+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "SourceContext": "Step_017_Context.Program"      // 로그 키(SourceContext)와 값(소스 위치)
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Program>();
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
        }
    }

    public class Foo
    {
        public void DoSomething()
        {
            // [10:03:49 INF] Hello Foo
            //
            // {
            //     "Timestamp": "2021-02-05T10:04:29.5341284+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "SourceContext": "Step_017_Context.Foo"          // 로그 키(SourceContext)와 값(소스 위치)
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Foo>();
            contextLogger.Information("Hello Foo");
        }
    }
}

