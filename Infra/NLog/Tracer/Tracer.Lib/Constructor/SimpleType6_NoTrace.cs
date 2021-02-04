using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Constructor
{
    [NoTrace]
    public class SimpleType6_NoTrace
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public SimpleType6_NoTrace(int x, List<int> values)
        {

        }
    }
}
