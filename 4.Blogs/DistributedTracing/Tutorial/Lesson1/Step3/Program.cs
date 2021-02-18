using System;
using Microsoft.Extensions.Logging;
using LessonLib;
//using OpenTracing;
using Jaeger;

namespace Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Expecting one argument");
            }

            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            using Tracer tracer = Tracing.Init("hello-world", loggerFactory);
            
            new Hello(tracer, loggerFactory).SayHello(args[0]);
        }
    }
}
