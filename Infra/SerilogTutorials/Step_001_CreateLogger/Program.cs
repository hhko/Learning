using Serilog;
using System;

namespace Step_001_CreateLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                .CreateLogger();

            log.Information("Hello World");
        }
    }
}
