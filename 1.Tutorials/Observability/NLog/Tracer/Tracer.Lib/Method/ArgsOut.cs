using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Method
{
    public class ArgsOut
    {
        [NoTrace]
        public ArgsOut()
        {

        }

        public string CallMe(out string param)
        {
            param = "rv";
            return "response";
        }

        public string CallMe(out int param)
        {
            param = 42;
            return "response";
        }

        public void CallMe(out MyStruct param)
        {
            param = new MyStruct() { IntVal = 24 };
        }

        public void CallMe(out MyClass param)
        {
            param = new MyClass() { IntVal = 24 };
        }
    }
}
