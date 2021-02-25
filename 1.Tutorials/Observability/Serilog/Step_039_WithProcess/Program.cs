using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_039_WithProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // 프로세스 Id
                                //
                                .Enrich.WithProcessId()

                                //
                                // 프로세스 이름
                                //
                                .Enrich.WithProcessName()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .CreateLogger();

            // {
            //     "Timestamp": "2021-02-25T14:39:41.5456777+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "ProcessId": 21984,                          <-- WithProcessId
            //         "ProcessName": "Step_039_WithProcess"        <-- WithProcessName
            //     }
            // }
            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}

