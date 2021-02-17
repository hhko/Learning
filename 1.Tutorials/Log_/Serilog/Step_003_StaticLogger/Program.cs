using Serilog;
using Serilog.Core;
using System;

namespace Step_003_StaticLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new LoggerConfiguration()
                                .WriteTo.Console()
                                .CreateLogger();

            //
            // 정적 로그 인스턴스
            //
            Log.Logger = log;

            Log.Verbose("Hello World");
            Log.Debug("Hello World");
            Log.Information("Hello World");
            Log.Warning("Hello World");
            Log.Error("Hello World");
            Log.Fatal("Hello World");

            //
            // 로그 인스턴스 파괴
            //
            Log.CloseAndFlush();
        }
    }
}
