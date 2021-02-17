using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step05_MultipleCodeCoverage1
{
    public class Class1
    {
        public int Method()
        {
            return 2020;
        }

        [ExcludeFromCodeCoverage]
        public void Exclude()
        {

        }
    }
}
