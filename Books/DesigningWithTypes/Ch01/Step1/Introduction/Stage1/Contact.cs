using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction.Stage1
{
    public class Contact
    {
        public string FirstName { get; set; }
        // use "option" to signal optionality
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        //true if ownership of email address is confirmed
        public bool IsEmailVerified { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        //true if validated against address service
        public bool IsAddressValid { get; set; }
    }
}
