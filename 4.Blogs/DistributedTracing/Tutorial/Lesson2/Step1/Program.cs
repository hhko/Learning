using System;
using Microsoft.Extensions.Logging;
using LessonLib;
using Jaeger;

namespace Step1
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
