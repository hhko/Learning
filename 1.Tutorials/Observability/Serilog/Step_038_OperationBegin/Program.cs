using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using System;
using System.Linq;

namespace Step_038_OperationBegin
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
            using (var op = Operation.Begin("Adding {Count} successive integers", count))   // Properties 키(Count)에 결과 값을 출력한다.
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");

                //
                // 기본 형식
                // [18:14:52 INF] Adding 10000 successive integers completed in 24.7 ms     <- Complete 호출할 때
                // [18:24:39 WRN] Adding 10000 successive integers abandoned in 23.2 ms     <- Complete 호출하지 않을 때
                //
                //  vs.
                //
                // JSON 형식
                // {
                //     "Timestamp": "2021-02-24T18:17:04.0048670+09:00",
                //     "Level": "Information",                  <- Time, Begin/Complete 기본 수준
                //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
                //     "Properties": {
                //         "Count": 10000,                      <- Begin 메서드 속성
                //         "Outcome": "completed",              <- 결과 타입 : completed(Information 수준), abandoned(Warning)
                //         "Elapsed": 24.5877,                  <- 수행 시간
                //         "Sum": 49995000                      <- Complete 메서드 속성
                //     },
                //     "Renderings": {
                //         "Elapsed": [
                //             {
                //             "Format": "0.0",
                //                 "Rendering": "24.6"          
                //             }
                //         ]
                //     }
                // }
                //

                // Complete 호출지 되지 않으면 "Outcome": "abandoned"(Warning 수준)으로 출력한다.
                //op.Complete();            
                op.Complete("Sum", sum);    // Properties 키(Sum)에 결과 값을 출력한다.
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}
