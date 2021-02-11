using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer.NLog;
using TracerAttributes;

namespace ConsoleAppTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var memoryTarget = new MemoryTarget
            //{
            //    Layout = "${level} ${message}"
            //};

            //SimpleConfigurator.ConfigureForTargetLogging(memoryTarget, LogLevel.Trace);

            //BenchmarkRunner.Run(typeof(Program).Assembly);

            //ConsoleTarget consoleTarget = new ConsoleTarget
            //{
            //    Layout = "${logger} ${level} ${message}"
            //};

            ////MemoryTarget memoryTarget = new MemoryTarget
            ////{
            ////    Layout = "${logger} ${level} ${message}"
            ////};

            ////SimpleConfigurator.ConfigureForTargetLogging(memoryTarget);
            //SimpleConfigurator.ConfigureForTargetLogging(consoleTarget);

            ////LogManager.Configuration = SimpleConfigurator.;

            //////var config = new LoggingConfiguration();

            //////var fileTarget = new FileTarget();
            //////fileTarget.FileName = "c:\\ApplicationLogs\\log_nlog2.txt";
            //////fileTarget.Layout = "${time}${logger}[${threadid}][${level}] ${event-properties:item=TypeInfo}.${event-properties:item=MethodInfo} - ${message}";

            //////config.AddTarget("file", fileTarget);
            //////config.AddRuleForAllLevels(fileTarget);

            //////LogManager.Configuration = config;
            ///

            //var config = new NLog.Config.LoggingConfiguration();
            //var memoryTarget = new NLog.Targets.MemoryTarget();
            //memoryTarget.Layout = "${message}";   // Message format
            //config.AddRuleForAllLevels(memoryTarget);
            //LogManager.Configuration = config;



            //Test test = new Test();
            //test.Something_NoTrace();
            //test.Something_Trace();

            Sample sample = new Sample();

            List<string> values = new List<string> { "x1", "x2", "x3" };
            sample.DoSomething(6, "hello", values);

            //sample.DoSomething2(6, "hello", values);

            //sample.X = 3;
        }
    }

    public class Test
    {
        [Benchmark(Baseline = true)]
        [NoTrace]
        public void Something_NoTrace()
        {
            Thread.Sleep(100);
        }

        [Benchmark]
        public void Something_Trace()
        {
            Thread.Sleep(100);
        }
    }

    //[TraceOn(TracerAttributes.TraceTarget.Protected)]
    //[TraceOn]
    public class Sample
    {
        //[NoReturnTrace]
        public List<string> DoSomething(int x, string s, List<string> values)
        {
            Log.OriginalLogger.Debug("Xyz1");

            X1();
            X2();
            X3();


            return values;
        }

        public int X { get; set; }

        [NoTrace]
        public int DoSomething2(int x, string s, List<string> values)
        {
            Log.Debug("Xyz2");

            X1();
            X2();
            X3();

            return 3;
        }

        public void X1()
        {

        }

        protected void X2()
        {

        }

        private void X3()
        {

        }
    }
}
