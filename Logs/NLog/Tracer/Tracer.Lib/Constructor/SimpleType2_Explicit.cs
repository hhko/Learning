using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Constructor
{
    public class SimpleType2_Explicit
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public SimpleType2_Explicit()
        {
        }
    }
}
