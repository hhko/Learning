using Serilog;
using System;

namespace Step_004_File
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()
                                //
                                // 파일 출력
                                //
                                .WriteTo.File("./Logs/LogFile.txt")
                                .CreateLogger();

            Log.Logger = log;
            Log.Information("Hello World");
        }
    }
}
