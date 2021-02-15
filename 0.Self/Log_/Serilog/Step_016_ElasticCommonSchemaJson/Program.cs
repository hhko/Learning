using Elastic.CommonSchema;
using Elastic.CommonSchema.Serilog;
using Serilog;
using System;
using Log = Serilog.Log;

namespace Step_016_ElasticCommonSchemaJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                //
                                // 출력 형식을 ElasticCommonSchema Json 형식으로 지정한다.
                                //
                                .WriteTo.Console(formatter: new EcsTextFormatter())
                                .WriteTo.File(path: "./Logs/LogFile.json", formatter: new EcsTextFormatter())
                                .CreateLogger();

            //
            // ElasticCommonSchema Json vs. Elasticsearch Json 차이점
            //   1. level -> log.level
            //   2. messageTemplate : x
            //   3. messageTemplate, fields -(통합)-> _metadata
            //   4. 추가 정보
            //      - ecs 버전(NuGet 패키지)
            //      - logger 이름
            //      - timezone
            //      - process : pid, thread id, 프로세스명, 파일명
            //  

            // ElasticCommonSchema Json
            // {
            //     "@timestamp": "2021-02-15T14:53:44.0173558+09:00",
            //     "log.level": "Information",
            //     "message": "Favorites : \"Foo\"",
            //     "_metadata": {
            //         "message_template": "Favorites : {UserName}",
            //         "user_name": "Foo"
            //     },
            //     "ecs": {
            //         "version": "1.5.0"
            //     },
            //     "event": {
            //         "severity": 2,
            //         "timezone": "대한민국 표준시",
            //         "created": "2021-02-15T14:53:44.0173558+09:00"
            //     },
            //     "log": {
            //         "logger": "Elastic.CommonSchema.Serilog",
            //         "original": null
            //     },
            //     "process": {
            //         "thread": {
            //             "id": 1
            //         },
            //         "pid": 42676,
            //         "name": "Step_016_ElasticCommonSchemaJson",
            //         "executable": "Step_016_ElasticCommonSchemaJson"
            //     }
            // }
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
            Log.Information("Favorites : {UserName}", "Foo");

            // ElasticCommonSchema Json
            // {
            //     "@timestamp": "2021-02-15T14:53:44.1789696+09:00",
            //     "log.level": "Information",
            //     "message": "Favorites : Foo",
            //     "_metadata": {
            //         "message_template": "Favorites : {UserName:l}",
            //         "user_name": "Foo"
            //     },
            //     "ecs": {
            //         "version": "1.5.0"
            //     },
            //     "event": {
            //         "severity": 2,
            //         "timezone": "대한민국 표준시",
            //         "created": "2021-02-15T14:53:44.1789696+09:00"
            //     },
            //     "log": {
            //         "logger": "Elastic.CommonSchema.Serilog",
            //         "original": null
            //     },
            //     "process": {
            //         "thread": {
            //             "id": 1
            //         },
            //         "pid": 42676,
            //         "name": "Step_016_ElasticCommonSchemaJson",
            //         "executable": "Step_016_ElasticCommonSchemaJson"
            //     }
            // }
            //
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
            Log.Information("Favorites : {UserName:l}", "Foo");

            // ElasticCommonSchema Json
            // {
            //     "@timestamp": "2021-02-15T14:53:44.191879+09:00",
            //     "log.level": "Information",
            //     "message": "Favorites : 3.141592653589793",
            //     "_metadata": {
            //         "message_template": "Favorites : {PI}",
            //         "pi": 3.141592653589793
            //     },
            //     "ecs": {
            //         "version": "1.5.0"
            //     },
            //     "event": {
            //         "severity": 2,
            //         "timezone": "대한민국 표준시",
            //         "created": "2021-02-15T14:53:44.191879+09:00"
            //     },
            //     "log": {
            //         "logger": "Elastic.CommonSchema.Serilog",
            //         "original": null
            //     },
            //     "process": {
            //         "thread": {
            //             "id": 1
            //         },
            //         "pid": 42676,
            //         "name": "Step_016_ElasticCommonSchemaJson",
            //         "executable": "Step_016_ElasticCommonSchemaJson"
            //     }
            // }
            //
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
            Log.Information("Favorites : {PI}", Math.PI);

            // ElasticCommonSchema Json
            // {
            //     "@timestamp": "2021-02-15T14:53:44.2085786+09:00",
            //     "log.level": "Information",
            //     "message": "Favorites : 3.14",
            //     "_metadata": {
            //         "message_template": "Favorites : {PI:0.00}",
            //         "pi": 3.141592653589793
            //     },
            //     "ecs": {
            //         "version": "1.5.0"
            //     },
            //     "event": {
            //         "severity": 2,
            //         "timezone": "대한민국 표준시",
            //         "created": "2021-02-15T14:53:44.2085786+09:00"
            //     },
            //     "log": {
            //         "logger": "Elastic.CommonSchema.Serilog",
            //         "original": null
            //     },
            //     "process": {
            //         "thread": {
            //             "id": 1
            //         },
            //         "pid": 42676,
            //         "name": "Step_016_ElasticCommonSchemaJson",
            //         "executable": "Step_016_ElasticCommonSchemaJson"
            //     }
            // }
            //
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
            Log.Information("Favorites : {PI:0.00}", Math.PI);

            Log.CloseAndFlush();
        }
    }
}




