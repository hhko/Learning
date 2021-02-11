using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Constructor
{
    public class SimpleType3_Args
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public SimpleType3_Args(int x, List<int> values)
        {

        }
    }
}
