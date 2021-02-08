using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtLoggingWithNLog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Microsoft.Extensions.Logging
            // Microsoft.Extensions.DependencyInjection
            // NLog
            // NLog.Extensions.Logging
            SimpleConfigurator.ConfigureForTargetLogging(new ConsoleTarget
            {
                Layout = "${message}"
            });

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ShardClass>();
            serviceCollection.AddLogging(log =>
            {
                log.AddNLog();
            });
            var services = serviceCollection.BuildServiceProvider();
            ShardClass shardClass = services.GetService<ShardClass>();
            shardClass.DoSomething();

            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("Main Hi");

        }
    }

    public class ShardClass
    {
        private readonly Microsoft.Extensions.Logging.ILogger<ShardClass> _logger;

        public ShardClass(Microsoft.Extensions.Logging.ILogger<ShardClass> logger)
        {
            _logger = logger;
        }
        public void DoSomething() => _logger.LogInformation("DoSomething ShardClass");
    }
}
