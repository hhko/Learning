using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_037_WithEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // 컴퓨터 이름
                                //
                                .Enrich.WithMachineName()

                                //
                                // 로그인 사용자 이름
                                //
                                .Enrich.WithEnvironmentUserName()

                                //
                                // ASPNETCORE_ENVIRONMENT or DOTNET_ENVIRONMENT 
                                //    우선 순위 : ASPNETCORE_ENVIRONMENT > DOTNET_ENVIRONMENT
                                //    둘다 없을 때 값은 "Production"이다.
                                //
                                .Enrich.WithEnvironmentName()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .CreateLogger();

            // {
            //     "Timestamp": "2021-02-25T14:19:08.0248777+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "MachineName": "DESKTOP-FAOR0RM",                        <-- WithMachineName
            //         "EnvironmentUserName": "DESKTOP-FAOR0RM\\hyungho.ko",    <-- WithEnvironmentUserName
            //         "EnvironmentName": "Production"                          <-- WithEnvironmentName
            //     }
            // }
            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}


