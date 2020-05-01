using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.ExtensionMethod
{
    public static class Extension1_Int
    {
        public static string Do(this int self, int value)
        {
            return (self + value).ToString();
        }
    }
}
