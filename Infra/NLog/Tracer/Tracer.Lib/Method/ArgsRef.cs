using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Method
{
    public class ArgsRef
    {
        [NoTrace]
        public ArgsRef()
        {

        }

        public void CallMe(ref string param)
        {
            param = "goinOut";
        }

        public void CallMe(ref int param)
        {
            param = 24;
        }

        public void CallMe(ref MyStruct param)
        {
            param = new MyStruct() { IntVal = 24 };
        }

        public void CallMe(ref MyClass param)
        {
            param = new MyClass() { IntVal = 24 };
        }
    }
}
