using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;

namespace Step_018_MinimumLevelContext
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()

                            //
                            // "SourceContext": "Step_018_MinimumLevelContext.Foo"
                            // - 네임스페이스부터 시작해야 한다(클래스명은 생략 가능하다).
                            //
                            .MinimumLevel.Override("Step_018_MinimumLevelContext.Foo", LogEventLevel.Fatal)
                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.txt")
                            .CreateLogger();

            //
            // "SourceContext"가 없기 때문에 .MinimumLevel.Override 영향을 받지 않는다.
            //
            Log.Information("Hello World");

            var foo = new Foo();
            foo.DoSomething();
        }
    }

    class Foo
    {
        public void DoSomething()
        {
            // [10:03:49 INF] Hello World Foo Fatal
            // 
            // {
            //     "Timestamp": "2021-02-05T10:04:29.5128059+09:00",
            //     "Level": "Fatal",
            //     "MessageTemplate": "Hello World Foo Fatal",
            //     "Properties": {
            //         "SourceContext": "Step_018_MinimumLevelContext.Foo"
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Foo>();
            contextLogger.Information("Hello World Foo");   // 출력 안됨
            contextLogger.Error("Hello World Foo Error");   // 출력 안됨
            contextLogger.Fatal("Hello World Foo Fatal");   // 출력 됨     .MinimumLevel.Override("Step_018_MinimumLevelContext.Foo", LogEventLevel.Fatal)
        }
    }
}
