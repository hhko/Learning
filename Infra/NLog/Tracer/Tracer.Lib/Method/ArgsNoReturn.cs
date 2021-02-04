using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Method
{
    public class ArgsNoReturn
    {
        [NoTrace]
        public ArgsNoReturn()
        {

        }

        public string CallMe()
        {
            return "response";
        }

        public MyStruct CallMeStruct()
        {
            return new MyStruct { IntVal = 2020 };
        }

        public MyClass CallMeClass()
        {
            return new MyClass { IntVal = 2020 };
        }

        public T CallaMeGeneric<T>() where T : new()
        {
            return new T();
        }

        [NoReturnTrace]
        public MyClass CallMeClassNoTrace()
        {
            return new MyClass { IntVal = 2020 };
        }
    }
}
