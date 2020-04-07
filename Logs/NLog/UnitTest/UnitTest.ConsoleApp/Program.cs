using Autofac;
using Autofac.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Lib;

namespace UnitTest.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Log 설정 파일을 지정한다.
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(@"Configurations\App.NLog.config");

            // NLog은 Tight Coupled일 때도 단위 테스트가 가능하다.
            TightCoupledNLog tightCoupledNLog = new TightCoupledNLog();
            tightCoupledNLog.Divide(2019, 10);

            // Autofac을 이용하여 ILogger을 주입시킨다.
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new LoggingModule());
            builder.RegisterType<LooseCoupledNLog>();
            IContainer container = builder.Build();

            using (var scop = container.BeginLifetimeScope())
            {
                LooseCoupledNLog looseCoupledNLog = scop.Resolve<LooseCoupledNLog>();
                looseCoupledNLog.Divide(2019, 10);
            }

            // Log을 정리한다.
            LogManager.Shutdown();
        }
    }
}
