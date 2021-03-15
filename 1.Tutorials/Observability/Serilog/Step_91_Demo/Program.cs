using CliFx;
using CliFx.Attributes;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using SerilogTimings.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Step_91_Demo
{
    class Program
    {
        public static async Task<int> Main()
        { 
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Verbose()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithAssemblyName()
                .Enrich.WithAssemblyVersion()
                .Enrich.WithProcessName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadName()
                .Enrich.WithThreadId()
                .Enrich.With<EventTypeEnricher>()

                .WriteTo.Http(
                    requestUri: "http://192.168.70.23:7701",
                    batchFormatter: new ArrayBatchFormatter(ByteSize.GB))
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {ProcessId} {NewLine}{Exception}")
                //.WriteTo.Console(formatter: new JsonFormatter())
                .CreateLogger();

            Thread.CurrentThread.Name = "Main Thread";

            var ret = await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();

            Log.CloseAndFlush();

            return ret;
        }
    }

    public class LogRandom
    {
        public static void Print(ILogger logger, Random rand, int value)
        {
            int level = rand.Next(1, 20);
            if (1 <= level && level <= 6)   // 6
            {
                logger.Verbose("{Sum}", value);
            }
            else if (7 <= level && level <= 11) // 5
            {
                logger.Debug("{Sum}", value);
            }
            else if (12 <= level && level <= 15) // 4
            {
                logger.Information("{Sum}", value);
            }
            else if (16 <= level && level <= 18) // 3
            {
                logger.Warning("{Sum}", value);
            }
            else if (18 <= level && level <= 19) // 2
            {
                logger.Error("{Sum}", value);
            }
            else if (level == 20) // 1
            {
                logger.Fatal("{Sum}", value);
            }
        }
    }

    [Command("Foo1")]
    public class Foo1Command : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            Random rand = new Random();

            while (true)
            {
                ILogger logger = Log.ForContext<Foo1Command>();
                using (var op = logger.BeginOperation("{MSG}", "hello"))
                {
                    int sleep = rand.Next(1, 10);
                    int sum = Enumerable.Range(0, sleep * 1000).Sum();

                    //Log.Information("{Sum}", sum);
                    LogRandom.Print(logger, rand, sum);

                    op.Complete("Sleep", sleep);
                }

                Thread.Sleep(3000);
            }

            return default;
        }
    }

    [Command("Foo2")]
    public class Foo2Command : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            Random rand = new Random();

            while (true)
            {
                ILogger logger = Log.ForContext<Foo2Command>();
                using (var op = logger.BeginOperation("{MSG}", "hello"))
                {
                    int sleep = rand.Next(1, 15);
                    int sum = Enumerable.Range(0, sleep * 1000).Sum();

                    //Log.Information("{Sum}", sum);
                    LogRandom.Print(logger, rand, sum);

                    op.Complete("Sleep", sleep);
                }

                Thread.Sleep(3000);
            }

            return default;
        }
    }

    [Command("Foo3")]
    public class Foo3Command : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            Random rand = new Random();

            while (true)
            {
                ILogger logger = Log.ForContext<Foo3Command>();
                using (var op = logger.BeginOperation("{MSG}", "hello"))
                {
                    int sleep = rand.Next(1, 20);
                    int sum = Enumerable.Range(0, sleep * 1000).Sum();

                    //Log.Information("{Sum}", sum);
                    LogRandom.Print(logger, rand, sum);

                    op.Complete("Sleep", sleep);
                }

                Thread.Sleep(3000);
            }

            return default;
        }
    }
}
