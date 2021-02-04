using Serilog;
using System;

namespace Step_015_GlobalMinimumLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            // 
                            // 전역 최소 로그 수준
                            //
                            // 1. 전역 최소 수준 로그는 Information이다.
                            //    "Information < Warning < Error < Fatal"만 로그를 출력한다.
                            //.MinimumLevel.Verbose() 
                            .MinimumLevel.Error()
                            .WriteTo.Console()
                            .WriteTo.File(path: "./Logs/LogFile.json")
                            .CreateLogger();

            // Verbose < Debug < Information < Warning < Error < Fatal
            //
            // Verbose      : 값, 세부 행위
            // Debug        : 값
            // Information  : 메서드 시작/끝, 주요 행위
            // Warning      : 실패(else) 
            // Error        : 예외
            // Fatal        : 더 이상 진행이 의미가 없을 때 : 예외, 실패(else)

            Log.Verbose("This is Verbose with {Value}", 1);
            Log.Debug("This is Debug with {Name}", 2);
            Log.Information("This is Information with {Name}", 3);
            Log.Warning("This is Warning with {Name}", 4);
            Log.Error("This is Error with {Name}", 5);
            Log.Fatal("This is Fatal with {Name}", 6);
        }
    }
}
