﻿using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using System;
using System.Linq;

namespace Step_037_OperationTime
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
            using (Operation.Time("Adding {Count} successive integers", count))   // Properties 키(Count)에 결과 값을 출력한다.
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");

                //
                // 기본 형식
                // [18:14:52 INF] Adding 10000 successive integers completed in 24.7 ms
                //
                //  vs.
                //
                // JSON 형식
                // {
                //     "Timestamp": "2021-02-25T11:04:55.0646945+09:00",
                //     "Level": "Information",                  <- Time, Begin/Complete 기본 수준
                //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
                //     "Properties": {
                //         "Count": 10000,                      <- Time 메서드 속성
                //         "Outcome": "completed",              <- 결과 타입 : completed(Information 수준), abandoned(Warning)
                //         "Elapsed": 21.4166                   <- 수행 시간
                //     },
                //     "Renderings": {
                //         "Elapsed": [
                //             {
                //             "Format": "0.0",
                //                 "Rendering": "21.4"
                //             }
                //         ]
                //     }
                // }
                //
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}




