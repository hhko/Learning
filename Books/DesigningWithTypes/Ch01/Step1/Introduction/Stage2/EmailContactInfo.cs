using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction.Stage2
{
    public class EmailContactInfo
    {
        public string EmailAddress { get; set; }
        //true if ownership of email address is confirmed
        public bool IsEmailVerified { get; set; }
    }
}
