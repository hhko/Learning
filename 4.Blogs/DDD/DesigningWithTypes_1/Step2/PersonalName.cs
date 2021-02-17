using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step2
{
    public class PersonalName
    {
        public string FirstName { get; set; }
        public Option<string> MiddleInitial { get; set; }
        public string LastName { get; set; }
    }
}
