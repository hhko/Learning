using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using System;
using System.IO;
using System.Threading;

namespace Step_028_MinimumLevelControlledByConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()

                    //
                    // 실행 경로
                    //
                    .SetBasePath(Directory.GetCurrentDirectory())

                    //
                    // reloadOnChange : 변경된 파일을 인식한다.
                    //
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            // 
            // 데모 시나리
            // 1. 프로그램 실행
            // 2. 실행 경로에 있는 "appsettings.json" 파일을 연다.
            // 3. "$consoleSwitch": "Verbose" 값을 변경하여 저장한다.
            //    - 상위 수준 변경 : Verbose -> Debug, Debug -> ...   
            //    - 하위 수준 변경 : Fatal -> Error, Error -> ...
            //    - 잘못된 수준 변경(반영하지 않는다) : 대소문, 오타 등 
            //

            //
            // 대소문자를 구분한다.
            //   올바른 예. Error
            //   잘못된 예. error
            //
            // "$consoleSwitch": "Verbose"
            // "$consoleSwitch": "Debug"
            // "$consoleSwitch": "Information"
            // "$consoleSwitch": "Warning"
            // "$consoleSwitch": "Error"
            // "$consoleSwitch": "Fatal"
            //

            //
            // MinimumLevel.ControlledBy : 전역 로그 Level
            //      "LevelSwitches": {
            //          "$appLogLevel": "Verbose"
            //      },
            //      "MinimumLevel": {
            //          "ControlledBy": "$appLogLevel"
            //      }
            //

            //
            // WriteTo(restrictedToMinimumLevel) : 특정 로그 Level
            //      "LevelSwitches": {
            //          "$consoleSwitch": "Verbose"
            //      },
            //      "WriteTo": [
            //          {
            //              "Name": "Console",
            //              "Args": {
            //                  "levelSwitch": "$consoleSwitch"
            //              }
            //          }
            //      ],
            //

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            bool keepRunning = true;
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                keepRunning = false;
            };

            while (keepRunning)
            {
                Log.Verbose("This is a Verbose log message");
                Log.Debug("This is a Debug log message");
                Log.Information("This is an Information log message");
                Log.Warning("This is a Warning log message");
                Log.Error("This is a Error log message");
                Log.Fatal("This is a Fatal log message");

                Thread.Sleep(3000);
            }

            Log.CloseAndFlush();
        }
    }
}
