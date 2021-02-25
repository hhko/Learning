using Serilog;
using Serilog.Formatting.Json;
using System;

namespace Step_038_WithAssemblyName
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // 어셈블리 이름
                                //
                                // .Enrich.WithAssemblyName<T>()
                                .Enrich.WithAssemblyName()

                                //
                                // 어셈블리 버전
                                //
                                // WithAssemblyVersion(bool useSemVer = false)
                                //  - 구현
                                //    var version = assembly.GetName().Version;
                                //    var versionString = useSemVer ? $"{version.Major}.{version.Minor}.{version.Build}" : $"{version}";
                                //
                                // WithAssemblyVersion<T>(bool useSemVer = false)
                                //  - Non Generic 구현
                                //    var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
                                //  - Generic 구현
                                //    var assembly = typeof(T).Assembly;
                                //
                                .Enrich.WithAssemblyVersion()
                                .WriteTo.Console(formatter: new JsonFormatter())
                                .CreateLogger();

            // {
            //     "Timestamp": "2021-02-25T14:25:48.4979721+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello World",
            //     "Properties": {
            //         "AssemblyName": "Step_038_WithAssemblyName",     <-- WithAssemblyName
            //         "AssemblyVersion": "1.0.0.0"                     <-- WithAssemblyVersion(useSemVer: false)
            //         "AssemblyVersion": "1.0.0"                       <-- WithAssemblyVersion(useSemVer: true)
            //     }
            // }
            Log.Information("Hello World");

            Log.CloseAndFlush();
        }
    }
}


