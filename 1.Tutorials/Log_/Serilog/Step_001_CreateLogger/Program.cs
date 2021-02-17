using Serilog;
using Serilog.Core;
using System;

namespace Step_001_CreateLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 로거 생성하기
            //
            Logger log = new LoggerConfiguration()
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
