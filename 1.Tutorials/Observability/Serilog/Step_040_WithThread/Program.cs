using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Threading;

namespace Step_040_WithThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // 스레드 Id
                                //
                                .Enrich.WithThreadId()

                                //
                                // 스레드 이름
                                //
                                // 이름이 없을 때(NULL)는 출력을 생략한다.
                                //   - 구현
                                //     var threadName = Thread.CurrentThread.Name;
                                //     if (threadName != null)
                                //     { ... }
                                .Enrich.WithThreadName()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .CreateLogger();

            // 메인 스레드는 이름이 없기 때문에 명시적으로 지정한다.
            Thread.CurrentThread.Name = "Main Thread";

            // {
            //     "Timestamp": "2021-02-25T15:20:56.2790710+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "ThreadId": 1,                       <-- WithThreadId
            //         "ThreadName": "Main Thread"          <-- WithThreadName
            //     }
            // }
            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}

