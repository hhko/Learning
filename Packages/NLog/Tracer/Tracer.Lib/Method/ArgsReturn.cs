using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Method
{
    public class ArgsReturn
    {
        [NoTrace]
        public ArgsReturn()
        {

        }

        public string CallMe(int value)
        {
            return (value + 1).ToString();
        }

        public string CallMeNoTraceArgs([NoTrace] int value)
        {
            return (value + 1).ToString();
        }

        [NoReturnTrace]
        public string CallMeNoTraceReturn(int value)
        {
            return (value + 1).ToString();
        }

        [NoReturnTrace]
        public string CallMeNoTraceArgsAndReturn([NoTrace] int value)
        {
            return (value + 1).ToString();
        }
    }
}
