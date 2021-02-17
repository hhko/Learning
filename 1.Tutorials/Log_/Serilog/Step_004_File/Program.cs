using Serilog;
using System;

namespace Step_004_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()

                                //
                                // 파일 출력
                                //
                                .WriteTo.File("./Logs/LogFile.txt")
                                .CreateLogger();

            Log.Verbose("Hello World");
            Log.Debug("Hello World");
            Log.Information("Hello World");
            Log.Warning("Hello World");
            Log.Error("Hello World");
            Log.Fatal("Hello World");

            Log.CloseAndFlush();
        }
    }
}
