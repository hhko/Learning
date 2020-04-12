using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.ExtensionMethod
{
    public static class Extension2_String
    {
        public static int Do(this string self, string value)
        {
            int value1, value2;
            int.TryParse(self, out value1);
            int.TryParse(value, out value2);

            return value1 + value2;
        }
    }
}
