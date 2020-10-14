using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._03._1_boolean
{
    public class Student1
    {
        public string Name { get; }
        public Semester Enrolled { get; private set; }
        private bool ComesFromExchange { get; }

        private Student1(bool comesFromExchange, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            ComesFromExchange = comesFromExchange;
            Name = name;
        }

        public static Student1 Create(string name) =>
            new Student1(false, name);

        public static Student1 CreateFromExchange(string name) =>
            new Student1(true, name);

        public int NameLength =>
            Name.Length;

        public char NameInitialLetter =>
            Name[0];

        public void Enroll(Semester semester)
        {
            if (semester == null ||
                !ComesFromExchange && semester.Predecessor != Enrolled)
                throw new ArgumentException(nameof(semester));

            Enrolled = semester;
        }
    }
}
