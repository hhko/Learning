using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._06
{
    public interface IExamApplication
    {
        public Subject Subject { get; }
        public Professor Admin { get; }
        public Student Candidate { get; }
    }
}
