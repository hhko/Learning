using Serilog;
using System;

namespace Step_002_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                                //
                                // 콜솔 출력
                                //
                                .WriteTo.Console()      
                                .CreateLogger();

            log.Information("Hello World");
        }
    }
}
