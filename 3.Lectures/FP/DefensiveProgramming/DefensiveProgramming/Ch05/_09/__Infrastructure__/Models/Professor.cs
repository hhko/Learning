using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._09.__Infrastructure__.Models
{
    public class Professor : PersistentObject
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
