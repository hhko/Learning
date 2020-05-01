using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.Tests
{
    public class LogSpec
    {
        protected readonly MemoryTarget _memoryTarget;

        public LogSpec()
        {
            _memoryTarget = new MemoryTarget
            {
                Layout = "${pad:padding=5:inner=${level:uppercase=true}} ${logger} ${message}"
            };

            SimpleConfigurator.ConfigureForTargetLogging(_memoryTarget, LogLevel.Trace);
        }
    }
}
