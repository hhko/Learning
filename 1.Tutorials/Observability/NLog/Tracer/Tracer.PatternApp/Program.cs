using NLog;
using NLog.Config;
using RootNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.PatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Configuration = new XmlLoggingConfiguration(@"Configurations\App.NLog.config");

            MyRepository myRepository = new MyRepository();
            myRepository.GetBy("Foo");
            myRepository.GetByUserId(2019);

            LogManager.Shutdown();
        }
    }
}
