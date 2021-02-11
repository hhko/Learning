using System;
using System.Collections.Generic;
using System.Text;

namespace Step2
{
    public class PostalContactInfo
    {
        public PostalAddress PostalAddress { get; set; }
        //true if validated against address service
        public string IsAddressValid { get; set; }
    }
}
