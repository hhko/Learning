using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._03
{
    public class Grade
    {
        public double NumericEquivalent { get; }

        private Grade(double numericEquivalent)
        {
            NumericEquivalent = numericEquivalent;
        }

        public static Grade A { get; } = new Grade(4);
        public static Grade B { get; } = new Grade(3);
        public static Grade Bminus { get; } = new Grade(2.67);
        public static Grade C { get; } = new Grade(2);
        public static Grade D { get; } = new Grade(1);
        public static Grade F { get; } = new Grade(0);
    }
}
