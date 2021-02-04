using Serilog;
using System;

namespace Step_006_FileSizeLimitBytes
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Not logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()

                                // fileSizeLimitBytes: 1073741824 (1GB)
                                //
                                // 1. 기본 파일 크기 제한은 1GB이다.
                                //    제한 크기 이상일 때는 추가하지 않는다(예외가 발생하지 않는다).
                                // 2. 무제한 로그 크기일 때는 "null"을 입력한다.

                                //.WriteTo.File(
                                //  "./Logs/LogFile.txt", 
                                //  outputTemplate: customTemplate, 
                                //  fileSizeLimitBytes: 200)            // 파일 크기 제한 : 200B
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate,
                                    fileSizeLimitBytes: null)           // 파일 크기 제한 : 무제한

                                .CreateLogger();

            Log.Logger = log;
            Log.Information("Hello World");
        }
    }
}
