using Serilog;
using Serilog.Events;
using System;

namespace Step_036_MultipleLogers
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Logger(l => l
                                .Filter.ByIncludingOnly(x => x.Level == LogEventLevel.Information || x.Level == LogEventLevel.Error)
                                .WriteTo.File("./Logs/LogFile_Info_and_Err.txt"))
                            .WriteTo.Logger(l => l
                                .Filter.ByIncludingOnly(x => x.Level == LogEventLevel.Fatal)
                                .WriteTo.File("./Logs/LogFile_Fatal.txt"))
                            .WriteTo.Console()
                            .CreateLogger();

            Log.Verbose("Hello World");             // Logged : Console
            Log.Debug("Hello World");               // Logged : Console
            Log.Information("Hello World");         // Logged : Console, LogFile_Info_and_Err.log
            Log.Warning("Hello World");             // Logged : Console
            Log.Error("Hello World");               // Logged : Console, LogFile_Info_and_Err.log
            Log.Fatal("Hello World");               // Logged : Console, LogFile_Fatal.log
        }
    }
}
