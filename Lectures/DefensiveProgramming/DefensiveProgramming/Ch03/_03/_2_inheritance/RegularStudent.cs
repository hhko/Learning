using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._03._2_inheritance
{
    public class RegularStudent : Student2
    {
        public RegularStudent(string name) : base(name) { }

        public override bool CanEnroll(Semester semester) =>
            semester != null && semester.Predecessor == base.Enrolled;
    }
}
