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

            var count = 10000;
            using (var op = Operation.Begin("Adding {Count} successive integers", count))   // Properties 키(Count)에 결과 값을 출력한다.
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");

                //
                // 기본 형식
                // [18:14:52 INF] Adding 10000 successive integers completed in 24.7 ms
                // [18:24:39 WRN] Adding 10000 successive integers abandoned in 23.2 ms
                //
                //  vs.
                //
                // JSON 형식
                // {
                //     "Timestamp": "2021-02-24T18:17:04.0048670+09:00",
                //     "Level": "Information",
                //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
                //     "Properties": {
                //         "Count": 10000,                      <- Begin 메서드 속성
                //         "Outcome": "completed",              <- 결과 타입 : completed, abandoned
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

                //op.Complete();            // Properties 키에 추가적인 결과를 출력하지 않는다.
                //op.Complete("Sum", sum);    // Properties 키(Sum)에 결과 값을 출력한다.
                op.Cancel();
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}

