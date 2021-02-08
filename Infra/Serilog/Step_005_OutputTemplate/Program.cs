using Serilog;
using System;

namespace Step_005_OutputTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate)     // 출력 형식 템플릿
                                .CreateLogger();

            Log.Logger = log;
            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}
