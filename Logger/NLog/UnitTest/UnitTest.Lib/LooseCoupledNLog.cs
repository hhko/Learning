using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Lib
{
    public class LooseCoupledNLog
    {
        private readonly ILogger _logger;

        
        public LooseCoupledNLog(ILogger logger)
        {
            _logger = logger;
        }

        public int Divide(int x, int y)
        {
            _logger.Trace("Divide - Entry");

            int ret = x / y;
            _logger.Info($"{x} / {y} = {ret}");

            _logger.Trace("Divide - Exit");
            return ret;
        }

        // 코드 커버리지에서 제외 대상으로 지정한다.
        [ExcludeFromCodeCoverage]
        public void DoSomething()
        {
            int x = 2019;
            int y = 10;
            _logger.Info($"{x}, {y}");
        }
    }
}
