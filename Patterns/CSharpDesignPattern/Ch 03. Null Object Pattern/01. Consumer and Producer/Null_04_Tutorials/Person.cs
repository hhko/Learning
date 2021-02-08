using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_Tutorials
{
    public class Person
    {
        public IAddress Address { get; }

        public Person(IAddress address)
        {
            Address = address;
        }
    }
}
