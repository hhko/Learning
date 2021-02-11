using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Method
{
    public class ArgsNoReturnNo
    {
        [NoTrace]
        public ArgsNoReturnNo()
        {

        }

        public void CallMe()
        {

        }
    }
}
