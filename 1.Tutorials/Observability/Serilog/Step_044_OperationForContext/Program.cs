using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using SerilogTimings.Extensions;
using System;
using System.Linq;

namespace Step_044_OperationForContext
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                //.WriteTo.Console()
                                .CreateLogger();

            Log.Information("Hello World");
            
            Foo foo = new Foo();
            foo.DoSomething();

            Log.CloseAndFlush();
        }
    }

    public class Foo
    {
        public void DoSomething()
        {
            //
            // {
            //     "Timestamp": "2021-02-25T13:16:43.5409441+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
            //     "Properties": {
            //         "Count": 10000,
            //         "Outcome": "completed",
            //         "Elapsed": 0.6968,
            //         "SourceContext": "Step_044_OperationForContext.Foo"      <-- 로그를 호출한 "네임스페이스.클래스"
            //     },
            //     "Renderings": {
            //         "Elapsed": [
            //             {
            //             "Format": "0.0",
            //                 "Rendering": "0.7"
            //             }
            //         ]
            //     }
            // }
            //

            //
            // ILogger Log.ForContext<T>();
            //
            // using SerilogTimings.Extensions;
            // ILogger 확장 메서드로 TimeOperation, BeginOperation, OperationAt을 제공한다.
            // 
            var count = 10000;
            using (Log.ForContext<Foo>().TimeOperation("Adding {Count} successive integers", count))
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");
            }
        }
    }
}


