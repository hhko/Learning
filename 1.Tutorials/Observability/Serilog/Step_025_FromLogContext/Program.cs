using Serilog;
using Serilog.Context;
using Serilog.Formatting.Json;
using System;

namespace Step_025_FromLogContext
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .Enrich.FromLogContext()
                            .WriteTo.Console(formatter: new JsonFormatter())
                            .CreateLogger();

            // Case 1. Witout LogContext
            //
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4122197+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Main Witout LogContext"
            // }
            Log.Information("Hello Main Witout LogContext");

            // Case 2. With LogContext
            //
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4305483+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Main",
            //     "Properties": {
            //         "Id": 1
            //     }
            // }
            //
            // IDisposable PushProperty(string name, object value, bool destructureObjects = false);
            //   - destructureObjects을 활용하여 "@" 연산자와 동일한 효과를 얻을 수 있다.
            //     예. using(LogContext.PushProperty("Id", foo, true)) 
            //
            using (LogContext.PushProperty("Id", 1))
            {
                Log.Information("Hello Main");
            }

            Foo foo = new Foo();

            // Case 3. With LogContext Individually
            //
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4330422+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Main",
            //     "Properties": {
            //         "Id": 1
            //     }
            // }
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4333264+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "Id": 2
            //     }
            // }
            using (LogContext.PushProperty("Id", 1))
            {
                Log.Information("Hello Main");
                foo.DoSomething();
            }

            // Case 4. With LogContext only Root : Propagation한다.
            //
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4334605+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Main",
            //     "Properties": {
            //         "Id": 1
            //     }
            // }
            // {
            //     "Timestamp": "2021-02-25T13:40:46.4336386+09:00",
            //     "Level": "Information",
            //     "MessageTemplate": "Hello Foo",
            //     "Properties": {
            //         "Id": 1
            //     }
            // }
            using (LogContext.PushProperty("Id", 1))
            {
                Log.Information("Hello Main");
                foo.DoSomethingWithoutLogContext();
            }

            Log.CloseAndFlush();
        }
    }

    public class Foo
    {
        public void DoSomething()
        {
            using (LogContext.PushProperty("Id", 2))
            {
                Log.Information("Hello Foo");
            }
        }

        public void DoSomethingWithoutLogContext()
        {
            Log.Information("Hello Foo");
        }
    }
}




