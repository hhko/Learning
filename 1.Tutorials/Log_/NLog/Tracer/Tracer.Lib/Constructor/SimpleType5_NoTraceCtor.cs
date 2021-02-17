using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Constructor
{
    public class SimpleType5_NoTraceCtor
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        [NoTrace]
        public SimpleType5_NoTraceCtor(int x, List<int> values)
        {

        }
    }
}
