using Serilog;
using System;

namespace Step_009_Scalar
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(path: "./Logs/LogFile.txt")
                                .CreateLogger();

            string name = "Foo";
            int age = 2021;
            DateTime created = DateTime.Now;
            Guid guid = Guid.NewGuid();

            // Console
            // [11:52:12 INF] User Foo, Age 2021. Created on 02/04/2021 11:52:12 - f297b0f6-d4ed-4a15-93bb-c8813303b326
            // 
            // File
            // Will be logged, This is a message 2021-02-04 11:52:12.663 +09:00 [INF] User Foo, Age 2021. Created on "2021-02-04T11:52:12.6580712+09:00" - "f297b0f6-d4ed-4a15-93bb-c8813303b326"
            //
            Log.Information("User {Name}, Age {Age}. Created on {Created} - {ID}", name, age, created, guid);

            Log.CloseAndFlush();
        }
    }
}
