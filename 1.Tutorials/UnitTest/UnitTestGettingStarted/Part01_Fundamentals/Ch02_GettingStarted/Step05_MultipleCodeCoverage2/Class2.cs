using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step05_MultipleCodeCoverage2
{
    public class Class2
    {
        public int Method()
        {
            return 9;
        }

        [ExcludeFromCodeCoverage]
        public void Exclude()
        {

        }
    }
}
