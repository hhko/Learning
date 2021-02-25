using Murmur;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Text;

namespace Step_036_CusstomPropertyMessageTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // MessageTemplate으로 Hash 값을 생성한 키를 생성한다.
                                //
                                .Enrich.With<EventTypeEnricher>()
                                //.WriteTo.Console(
                                //    //outputTemplate: "{Timestamp:HH:mm:ss} [{EventType:x8} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                                //    outputTemplate: "{Timestamp:HH:mm:ss} [{EventType} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .CreateLogger();

            // 13:53:59 [83A6FC9E INF] Hello World1
            // 13:53:59 [83A6FC9E INF] Hello World2
            //
            // {
            //     "Timestamp": "2021-02-25T13:55:21.3838065+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello {MSG}",
            //     "Properties": {
            //         "MSG": "World1",
            //         "EventType": 83A6FC9E                  <-- MessageTemplate으로 만든 Hash 값
            //     }
            // }
            // {
            //     "Timestamp": "2021-02-25T13:55:21.4046004+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello {MSG}",
            //     "Properties": {
            //         "MSG": "World2",
            //         "EventType": 83A6FC9E                  <-- MessageTemplate으로 만든 Hash 값
            //     }
            // }
            Log.Information("Hello {MSG}", "World1");
            Log.Information("Hello {MSG}", "World2");

            // 13:53:59 [2B048590 INF] Hello World3
            // 13:53:59 [2B048590 INF] Hello World4
            //
            // {
            //     "Timestamp": "2021-02-25T13:55:21.4049878+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello {MESSAGE}",
            //     "Properties": {
            //         "MESSAGE": "World3",
            //         "EventType": 2B048590                  <-- MessageTemplate으로 만든 Hash 값
            //     }
            // }
            // {
            //     "Timestamp": "2021-02-25T13:55:21.4051335+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello {MESSAGE}",
            //     "Properties": {
            //         "MESSAGE": "World4",
            //         "EventType": 2B048590                  <-- MessageTemplate으로 만든 Hash 값
            //     }
            // }
            Log.Information("Hello {MESSAGE}", "World3");
            Log.Information("Hello {MESSAGE}", "World4");

            Log.CloseAndFlush();
        }
    }
}




