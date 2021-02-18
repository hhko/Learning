using System;
using Microsoft.Extensions.Logging;

namespace Step2
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
            new Hello(loggerFactory).SayHello(args[0]);
        }
    }
}
