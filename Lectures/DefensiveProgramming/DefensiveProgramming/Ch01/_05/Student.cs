using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._05
{
    public class Student
    {
        public Semester Enrolled { get; }

        public bool HasPassedExam(Subject subject)
        {
            return true;
        }
    }
}
