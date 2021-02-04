using Serilog;
using System;

namespace Step_007_RollingInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Will be logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()

                                // rollingInterval
                                //
                                // 1. 기본 Rolling 값은 Infinite(한 파일에 쓰기)이다.
                                // 2. Day일 때는 "년원일" 형식으로 Paht 뒤에 자동으로 추가된다.
                                //      LogFile.txt -> LogFile20210204.txt

                                //.WriteTo.File("./Logs/LogFile.txt", outputTemplate: customTemplate, fileSizeLimitBytes: 200)
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt", 
                                    outputTemplate: customTemplate, 
                                    fileSizeLimitBytes: null,
                                    rollingInterval: RollingInterval.Day)

                                .CreateLogger();

            Log.Logger = log;
            Log.Information("Hello World");
        }
    }
}
