using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.ExtensionMethod
{
    public static class Extension4_Class
    {
        public static int Do(this MyClass self, int value)
        {
            return value + 1;
        }
    }
}
