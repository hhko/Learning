using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._03._2_inheritance
{
    public class ExchangeStudent : Student2
    {
        public ExchangeStudent(string name) : base(name) { }

        public override bool CanEnroll(Semester semester) =>
            semester != null;
    }
}
