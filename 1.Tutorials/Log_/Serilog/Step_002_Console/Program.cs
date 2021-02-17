using Serilog;
using Serilog.Core;
using System;

namespace Step_002_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new LoggerConfiguration()

                                //
                                // 콜솔 출력
                                //
                                .WriteTo.Console()      
                                .CreateLogger();

            log.Verbose("Hello World");
            log.Debug("Hello World");
            log.Information("Hello World");
            log.Warning("Hello World");
            log.Error("Hello World");
            log.Fatal("Hello World");

            log.Dispose();
        }
    }
}
