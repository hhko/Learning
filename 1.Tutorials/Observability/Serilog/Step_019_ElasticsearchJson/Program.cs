using Serilog;
using Serilog.Formatting.Elasticsearch;
using System;

namespace Step_015_ElasticsearchJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                //
                                // 출력 형식을 Elasticsearch Json 형식으로 지정한다.
                                //
                                .WriteTo.Console(formatter: new ElasticsearchJsonFormatter())
                                .WriteTo.File(path: "./Logs/LogFile.json", formatter: new ElasticsearchJsonFormatter())
                                .CreateLogger();

            //
            // Elasticsearch Json vs. Json 차이점
            //   1. @timestamp이다.
            //   2. 키가 소문자로 시작한다.
            //   3. "message"키가 있다.
            //   4. Properties -> fields 이름이 다르다.
            //

            // Elasticsearch Json
            // {
            //     "@timestamp": "2021-02-15T14:40:05.9033324+09:00",
            //     "level": "Information",
            //     "messageTemplate": "Favorites : {UserName}",
            //     "message": "Favorites : \"Foo\"",                <- Elasticsearch Json
            //     "fields": {
            //         "UserName": "Foo"
            //     }
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

            // Elasticsearch Json
            // {
            //     "@timestamp": "2021-02-15T14:40:05.9226900+09:00",
            //     "level": "Information",
            //     "messageTemplate": "Favorites : {UserName:l}",
            //     "message": "Favorites : Foo",
            //     "fields": {
            //         "UserName": "Foo"
            //     },
            //     "renderings": {
            //         "UserName": [
            //             {
            //                 "Format": "l",
            //                 "Rendering": "Foo"
            //             }
            //         ]
            //     }
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

            // Elasticsearch Json
            // {
            //     "@timestamp": "2021-02-15T14:40:05.9248479+09:00",
            //     "level": "Information",
            //     "messageTemplate": "Favorites : {PI}",
            //     "message": "Favorites : 3.141592653589793",
            //     "fields": {
            //         "PI": 3.141592653589793
            //     }
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

            // Elasticsearch Json
            // {
            //     "@timestamp": "2021-02-15T14:40:05.9253807+09:00",
            //     "level": "Information",
            //     "messageTemplate": "Favorites : {PI:0.00}",
            //     "message": "Favorites : 3.14",
            //     "fields": {
            //         "PI": 3.141592653589793
            //     },
            //     "renderings": {
            //         "PI": [
            //             {
            //                 "Format": "0.00",
            //                 "Rendering": "3.14"
            //             }
            //         ]
            //     }
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
