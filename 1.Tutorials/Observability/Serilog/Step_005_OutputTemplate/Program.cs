using Serilog;
using System;

namespace Step_005_OutputTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 출력 형식 사용자 정의
            //
            const string customTemplate = "This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console(
                                    outputTemplate: customTemplate)     // 출력 형식
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate)     // 출력 형식
                                .CreateLogger();

            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}
