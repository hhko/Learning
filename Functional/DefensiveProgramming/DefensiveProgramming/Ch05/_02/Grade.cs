using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._02
{
    public class Grade
    {
        private Grade()
        {
        }

        public static Grade A { get; } = new Grade();
        public static Grade B { get; } = new Grade();
        public static Grade C { get; } = new Grade();
        public static Grade D { get; } = new Grade();
        public static Grade F { get; } = new Grade();
    }
}
