using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

namespace Step2
{
    public class EmailContactInfo
    {
        public EmailAddress EmailAddress { get; set; }
        //true if ownership of email address is confirmed
        public string IsEmailVerified { get; set; }
    }

    
}
