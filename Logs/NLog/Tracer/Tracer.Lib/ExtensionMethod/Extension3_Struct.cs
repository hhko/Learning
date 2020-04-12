using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.ExtensionMethod
{
    public static class Extension3_Struct
    {
        public static int Do(this MyStruct self, int value)
        {
            return value + 1;
        }
    }
}
