using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_Tutorials
{
    public class Address : IAddress
    {
        public string Country { get; }

        public Address(string country)
        {
            Country = country;
        }
    }
}
