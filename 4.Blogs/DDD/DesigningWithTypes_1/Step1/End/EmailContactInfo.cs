using System;
using System.Collections.Generic;
using System.Text;

namespace Step1.End
{
    public class EmailContactInfo
    {
        public string EmailAddress { get; set; }
        //true if ownership of email address is confirmed
        public string IsEmailVerified { get; set; }
    }
}
