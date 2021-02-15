using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;

namespace Step_014_CompactJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                //
                                // 출력 형식을 Json 형식으로 지정한다.
                                //
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                                .WriteTo.File(path: "./Logs/LogFileCompact.json", formatter: new CompactJsonFormatter())
                                .CreateLogger();

            // Compact Json
            // {
            //     "@t": "2021-02-15T05:00:04.0379846Z",
            //     "@mt": "Favorites : {UserName}",
            //     "UserName": "Foo"
            // }
            //
            // Json
            // {
            //     "Timestamp": "2021-02-15T14:00:04.0379846+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Favorites : {UserName}",
            //     "Properties": {
            //         "UserName": "Foo"
            //     }
            // }
            Log.Information("Favorites : {UserName}", "Foo");

            // Compact Json
            // {
            //     "@t": "2021-02-15T05:00:04.0562787Z",
            //     "@mt": "Favorites : {UserName:l}",
            //     "@r": [
            //         "Foo"
            //     ],
            //     "UserName": "Foo"
            // }
            //
            // Json
            // {
            //     "Timestamp": "2021-02-15T14:00:04.0562787+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Favorites : {UserName:l}",
            //     "Properties": {
            //         "UserName": "Foo"                // 원본 값
            //     },
            //     "Renderings": {                      // 형식 지정이 있을 때만 생성된다.
            //         "UserName": [
            //             {
            //                 "Format": "l",           // 형식
            //                 "Rendering": "Foo"       // 형식이 반영된 값
            //             }
            //         ]
            //     }
            // }
            Log.Information("Favorites : {UserName:l}", "Foo");

            // Compact Json
            // {
            //     "@t": "2021-02-15T05:00:04.0593361Z",
            //     "@mt": "Favorites : {PI}",
            //     "PI": 3.141592653589793
            // }
            //
            // Json
            // {
            //     "Timestamp": "2021-02-15T14:00:04.0593361+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Favorites : {PI}",
            //     "Properties": {
            //         "PI": 3.141592653589793
            //     }
            // }
            Log.Information("Favorites : {PI}", Math.PI);

            // Compact Json
            // {
            //     "@t": "2021-02-15T05:00:04.0599895Z",
            //     "@mt": "Favorites : {PI:0.00}",
            //     "@r": [
            //         "3.14"
            //     ],
            //     "PI": 3.141592653589793
            // }
            //
            // Json
            // {
            //     "Timestamp": "2021-02-15T14:00:04.0599895+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Favorites : {PI:0.00}",
            //     "Properties": {
            //         "PI": 3.141592653589793          // 원본 값
            //     },
            //     "Renderings": {                      // 형식 지정이 있을 때만 생성된다.
            //         "PI": [
            //             {
            //                 "Format": "0.00",        // 형식
            //                 "Rendering": "3.14"      // 형식이 반영된 값
            //             }
            //         ]
            //     }
            // }
            Log.Information("Favorites : {PI:0.00}", Math.PI);

            Log.CloseAndFlush();
        }
    }
}
