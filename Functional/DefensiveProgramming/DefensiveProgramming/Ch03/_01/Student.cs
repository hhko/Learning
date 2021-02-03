using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._01
{
    public class Student
    {
        public string Name { get; set; }

        public int NameLength
        {
            get
            {
                if (Name != null)
                    return Name.Length;
                else
                    return 0;
            }
        }

        public char NameInitialLetter
        {
            get
            {
                if (Name != null && Name.Length > 0)
                    return Name[0];
                else
                    return 'A';
            }
        }
    }
}
