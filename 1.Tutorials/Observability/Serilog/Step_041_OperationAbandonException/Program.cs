using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using System;
using System.Linq;


namespace Step_041_OperationAbandonException
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
                try
                {
                    var sum = Enumerable.Range(0, count).Sum();
                    Log.Information("This event is tagged with an operation id");

                    throw new DivideByZeroException("예외 발생하기");
                }
                catch (Exception exp)
                {
                    //
                    // 기본 형식
                    // [18:24:39 WRN] Adding 10000 successive integers abandoned in 23.2 ms     <- Abandon 호출할 때
                    //
                    //  vs.
                    //
                    // JSON 형식
                    // {
                    //     "Timestamp": "2021-02-24T18:17:04.0048670+09:00",
                    //     "Level": "Warning",                      <- Begin/Abandon 기본 수준
                    //     "MessageTemplate": "Adding {Count} successive integers {Outcome} in {Elapsed:0.0} ms",
                    //     "Exception": "System.DivideByZeroException: 예외 발생하기\r\n   at ...(어셈블리명)... .Program.Main(String[] args) in C:\\ ... \\Program.cs:line 29",
                    //     "Properties": {
                    //         "Count": 10000,                      <- Begin 메서드 속성
                    //         "Outcome": "abandoned",              <- 결과 타입 : completed(Information 수준), abandoned(Warning)
                    //         "Elapsed": 24.5877,                  <- 수행 시간
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

                    // void Abandon();
                    // void Abandon(this Operation operation, string resultPropertyName, object result, bool destructureObjects = false);
                    // void Abandon(this Operation operation, ILogEventEnricher enricher);
                    // void Abandon(this Operation operation, IEnumerable<ILogEventEnricher> enrichers); 
                    // void Abandon(this Operation operation, Exception exception);
                    //  - 구현
                    //  public static void Abandon(this Operation operation, Exception exception)
                    //  {
                    //      operation
                    //          .SetException(exception)
                    //          .Abandon();
                    //  }
                    op.Abandon(exp);
                }
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}
