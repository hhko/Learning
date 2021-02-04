using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.ExtensionMethod
{
    public static class Extension5_Generic
    {
        public static int DoStruct<T>(this T self, int value) where T : struct
        {
            return value + 1;
        }

        public static int DoClass<T>(this T self, int value) where T : class
        {
            return value + 1;
        }
    }
}
