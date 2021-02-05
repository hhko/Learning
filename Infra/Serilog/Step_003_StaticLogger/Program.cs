using Serilog;
using System;

namespace Step_003_StaticLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()
                                .CreateLogger();

            //
            // 정적 로그 인스턴스
            //
            Log.Logger = log;
            Log.Information("Hello World");
        }
    }
}
