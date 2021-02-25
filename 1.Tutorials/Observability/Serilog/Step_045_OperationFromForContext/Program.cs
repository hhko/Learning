using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using SerilogTimings.Extensions;
using System;
using System.Linq;

namespace Step_045_OperationFromForContext
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .Enrich.FromLogContext()
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
            // {
            //     "Timestamp": "2021-02-25T16:40:19.9386247+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
            //     "Properties": {
            //         "Count": 10000,
            //         "Outcome": "completed",
            //         "Elapsed": 2.3742,
            //         "SourceContext": "Step_045_OperationFromForContext.Foo",
            //         "OperationId": "fdeaa307-67c2-47ad-bef2-9b7c63d19827"        <-- .Enrich.FromLogContext()
            //     },
            //     "Renderings": {
            //         "Elapsed": [
            //             {
            //             "Format": "0.0",
            //                 "Rendering": "2.4"
            //             }
            //         ]
            //     }
            // }

            var count = 10000;
            using (Log.ForContext<Foo>().TimeOperation("Adding {Count} successive integers", count))
            {
                var sum = Enumerable.Range(0, count).Sum();

                // {
                //     "Timestamp": "2021-02-25T16:40:19.9323516+09:00",
                //     "Level": "Information",
                //     "MessageTemplate": "This event is tagged with an operation id",
                //     "Properties": {
                //         "OperationId": "fdeaa307-67c2-47ad-bef2-9b7c63d19827"    <-- .Enrich.FromLogContext()
                //     }
                // }
                Log.Information("This event is tagged with an operation id");
            }
        }
    }
}



