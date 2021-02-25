using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using SerilogTimings;
using System;
using System.Linq;

namespace Step_040_OperationCancel
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                //.WriteTo.Console()
                                .CreateLogger();

            // MessageTemplate : " ... {Outcome} in {Elapsed:0.0} ms
            var count = 10000;
            using (var op = Operation.Begin("Adding {Count} successive integers", count))   // Properties 키(Count)에 결과 값을 출력한다.
            {
                var sum = Enumerable.Range(0, count).Sum();
                Log.Information("This event is tagged with an operation id");

                //
                // 기본 형식
                // (없음)
                //
                //  vs.
                //
                // JSON 형식
                // (없음)
                //

                // Complete 호출지 되지 않으면 "Outcome": "abandoned"(Warning 수준)으로 출력한다.
                // Cancel은 로그를 출력하지 않는다.
                op.Cancel();
            }

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}
