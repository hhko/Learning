using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Tracer.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Configuration = new XmlLoggingConfiguration(@"Configurations\App.NLog.config");

            BenchmarkRunner.Run<Foo>();

            //Foo f = new Foo();
            //f.Do_NLog_Manual();
            //f.Do_NLog_AutoN();
            //MemoryTarget target = LogManager.Configuration.FindTargetByName<MemoryTarget>("c");
            //IList<string> logs = target.Logs;

            LogManager.Shutdown();
        }
    }
}
