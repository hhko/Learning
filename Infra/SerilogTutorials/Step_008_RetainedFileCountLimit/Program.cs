using Serilog;
using System;

namespace Step_008_RetainedFileCountLimit
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Will be logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()

                                // retainedFileCountLimit
                                //
                                // 1. 기본 보존 파일 개수는 31개이다.
                                //    제한 크기 이상일 때는 가장 오랜된 파일을 삭제하고 새 파일을 생성한다.

                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate,
                                    fileSizeLimitBytes: null,
                                    rollingInterval: RollingInterval.Day,
                                    retainedFileCountLimit: 2)              // 파일 개수 제한

                                .CreateLogger();

            Log.Logger = log;
            Log.Information("Hello World");
        }
    }
}
