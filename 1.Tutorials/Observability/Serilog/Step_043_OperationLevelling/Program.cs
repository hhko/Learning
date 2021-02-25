using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using SerilogTimings;
using System;
using System.Linq;

namespace Step_041_OperationLevelling
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                //.WriteTo.Console()
                                .CreateLogger();

            // MessageTemplate : " ... {Outcome} in {Elapsed:0.0} ms"
            var count = 10000;
            using (Operation.At(LogEventLevel.Error).Time("Adding {Count} successive integers", count))   // Properties 키(Count)에 결과 값을 출력한다.
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");

                //
                // 기본 형식
                // [11:35:45 ERR] Adding 10000 successive integers completed in 33.6 ms
                //
                //  vs.
                //
                // JSON 형식
                // {
                //     "Timestamp": "2021-02-25T11:31:44.4051832+09:00",
                //     "Level": "Error",                        <- Operation.At(LogEventLevel.Error) 지정한 수준
                //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
                //     "Properties": {
                //         "Count": 10000,                      <- Time 메서드 속성
                //         "Outcome": "completed",              <- 결과 타입 : completed(Information 수준), abandoned(Warning)
                //         "Elapsed": 42.0575                   <- 수행 시간
                //     },
                //     "Renderings": {
                //         "Elapsed": [
                //             {
                //             "Format": "0.0",
                //                 "Rendering": "42.1"
                //             }
                //         ]
                //     }
                // }
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}



