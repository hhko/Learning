﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Step2
{
    public class PostalAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public StateCode State { get; set; }
        public ZipCode Zip { get; set; }
    }
}
