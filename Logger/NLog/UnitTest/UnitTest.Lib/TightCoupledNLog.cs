using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Lib
{
    public class TightCoupledNLog
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public int Divide(int x, int y)
        {
            _logger.Trace("Divide - Entry");

            int ret = x / y;
            _logger.Info($"{x} / {y} = {ret}");

            _logger.Trace("Divide - Exit");
            return ret;
        }
    }
}
