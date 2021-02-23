using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.IO;

namespace Step_027_MinimumLevelControlledBy
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 기본 수준은 "Information" 이다.
            //
            var globalLevelSwitch = new LoggingLevelSwitch();
            var consoleLevelSwitch = new LoggingLevelSwitch();

            Log.Logger = new LoggerConfiguration()

                //
                // LoggerConfiguration ControlledBy(LoggingLevelSwitch levelSwitch);
                //
                .MinimumLevel.ControlledBy(globalLevelSwitch)

                //
                // LoggingLevelSwitch levelSwitch = null
                //
                .WriteTo.Console(levelSwitch: consoleLevelSwitch)
                .CreateLogger();

            Log.Verbose("Hello World - 1");
            Log.Debug("Hello World - 1");
            Log.Information("Hello World - 1");         // Logged
            Log.Warning("Hello World - 1");             // Logged
            Log.Error("Hello World - 1");               // Logged
            Log.Fatal("Hello World - 1");               // Logged

            consoleLevelSwitch.MinimumLevel = LogEventLevel.Error;

            Log.Verbose("Hello World - 2");
            Log.Debug("Hello World - 2");
            Log.Information("Hello World - 2");
            Log.Warning("Hello World - 2");
            Log.Error("Hello World - 2");               // Logged
            Log.Fatal("Hello World - 2");               // Logged

            Log.CloseAndFlush();
        }
    }
}
