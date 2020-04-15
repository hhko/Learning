using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction.Stage2
{
    public class PostalContactInfo
    {
        public PostalAddress Address { get; set; }
        // true if validated against address service
        public bool IsAddressValid { get; set; }
    }
}
