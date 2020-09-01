using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step05_MultipleCodeCoverage3
{
    public class Class3
    {
        public int Method()
        {
            return 1;
        }

        //[ExcludeFromCodeCoverage]
        public void Exclude()
        {

        }
    }
}
