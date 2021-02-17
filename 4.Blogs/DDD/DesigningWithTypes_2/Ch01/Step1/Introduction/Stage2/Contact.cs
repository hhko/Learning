using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction.Stage2
{
    public class Contact
    {
        // 이름
        public PersonalName Name { get; set; }

        // 메일
        public EmailContactInfo EmailContactInfo { get; set; }

        // 주소
        public PostalContactInfo PostalContactInfo { get; set; }
    }
}
