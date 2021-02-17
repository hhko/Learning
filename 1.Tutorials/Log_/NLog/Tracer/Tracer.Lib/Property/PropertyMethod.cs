using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerAttributes;

namespace Tracer.Lib.Property
{
    public class PropertyMethod
    {
        [NoTrace]
        public PropertyMethod()
        {

        }

        public int IntValueGet
        {
            get { return 1; }
        }

        private int _intValue;
        public int IntValueSet
        {
            set { _intValue = value; }
        }
    }
}
