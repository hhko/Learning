using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._03._2_inheritance
{
    public abstract class Student2
    {
        public string Name { get; }
        public Semester Enrolled { get; private set; }

        protected Student2(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        public int NameLength =>
            Name.Length;

        public char NameInitialLetter =>
            Name[0];

        public abstract bool CanEnroll(Semester semester);

        public void Enroll(Semester semester)
        {
            if (!CanEnroll(semester))
                throw new ArgumentException(nameof(semester));

            Enrolled = semester;
        }
    }
}
