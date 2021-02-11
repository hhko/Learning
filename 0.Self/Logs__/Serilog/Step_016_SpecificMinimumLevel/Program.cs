using Serilog;
using Serilog.Events;
using System;

namespace Step_016_SpecificMinimumLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()

                            // 
                            // 출력 단위 로그 최소 수준
                            //
                            // 1. 전역 최소 수준에서 출력 단위로 로그 최소 수준을 지정한다.
                            // 2. 출력 단위 로그 최소 수준은 Verbose.
                            //    "Verbose < Debug < Information < Warning < Error < Fatal"
                            //    전역 로그 취소 수준을 반영할 수 있는 기본 설정이다.
                            //
                            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)

                            .WriteTo.File(path: "./Logs/LogFile.txt")
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

            Log.CloseAndFlush();
        }
    }
}
