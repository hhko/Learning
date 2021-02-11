using Serilog;
using Serilog.Core;
using Serilog.Filters;
using Serilog.Formatting.Json;
using System;

namespace Step_018_MatchingFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Console(formatter: new JsonFormatter())
                            .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())

                            // .Filter.ByExcluding      : 제외, OR 조건
                            // .Filter.ByIncludingOnly  : 포함, AND 조건
                            //  1. Matching
                            //     - FromSource<T>      : SourceContext 키의 값(Generic)
                            //     - FromSource         : SourceContext 키의 값(string)
                            //     - WithProperty       : 키 
                            //     - WithProperty       : 키와 값(string)
                            //     - WithProperty<T>    : 키와 값(Generic)
                            //  2. LogEvent
                            //     - Timestamp          : DateTimeOffset
                            //     - Level              : LogEventLevel
                            //     - MessageTemplate    : MessageTemplate
                            //     - Properties         : IReadOnlyDictionary<string, LogEventPropertyValue>
                            //       ※ Matching과 동일하다.
                            //     - Exception          : Exception


                            // 1.1 "SourceContext" 키의 값 기준 필터
                            //
                            // "SourceContext" 키의 "Step_017_Context.Program" 값 로그를 제외 시킨다.
                            .Filter.ByExcluding(Matching.FromSource<Program>())
                            //.Filter.ByExcluding(Matching.FromSource("Step_018_MatchingFilter"))           // 네임스페이스
                            //.Filter.ByExcluding(Matching.FromSource("Step_018_MatchingFilter.Program"))   // 클래스

                            // 1.2 키 기준 필터
                            //
                            // "SourceContext" 키 로그를 제외 시킨다.
                            //.Filter.ByExcluding(Matching.WithProperty(Constants.SourceContextPropertyName))
                            // "Name" 키 로그를 제외 시킨다.
                            .Filter.ByExcluding(Matching.WithProperty("Name"))

                            // 1.3 키와 값 기준 필터
                            //
                            // "SourceContext" 키의 "Step_017_Context.Program" 값 로그를 제외 시킨다.
                            //.Filter.ByExcluding(Matching.WithProperty(Constants.SourceContextPropertyName, "Step_018_MatchingFilter.Program"))

                            .CreateLogger();

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
            ILogger contextLogger = Log.ForContext<Program>();          // Filert : O, .Filter.ByExcluding(Matching.FromSource<Program>())
            contextLogger.Information("Hello World");

            // {
            //     "Timestamp": "2021-02-05T13:21:40.9440566+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "{Name}",
            //     "Properties": {
            //         "Name": "Filter"                                 // 로그 키(Name)와 값(Filter)
            //     }
            // }
            Log.Information("{Name}", "Filter");                        // Filert : O, .Filter.ByExcluding(Matching.WithProperty("Name"))

            // [10:03:49 INF] Hello World from Non-Context
            //
            // {
            //     "Timestamp": "2021-02-05T10:07:32.1467764+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World2"
            // }
            Log.Information("Hello World from Non-Context");            // Filter : X

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
            //     "Timestamp": "2021-02-05T10:04:29.5341284+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "SourceContext": "Step_017_Context.Foo"          // 로그 키(SourceContext)와 값(소스 위치)
            //     }
            // }
            ILogger contextLogger = Log.ForContext<Foo>();
            contextLogger.Information("Hello Foo");                     // Filter : X
        }
    }
}