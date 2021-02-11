using System;
using System.Collections.Generic;
using System.Text;

namespace Step2
{
    public class Contact
    {
        public PersonalName Name { get; set; }

        public EmailContactInfo EmailContactInfo { get; set; }

        public PostalContactInfo PostalContactInfo { get; set; }
    }
}
