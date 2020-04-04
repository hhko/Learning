using System;
using System.Collections.Generic;
using System.Text;

namespace PrimitiveObsession.Stage2
{
    public enum Risk { Low, Medium, High }

    public class Calculate
    {
        public static Risk CalculateRiskProfile(int age)
        {
            if (age < 0 || age >= 120)
                throw new ArgumentException($"{age} is not valid age");

            return (age < 60)
                ? Risk.Low
                : Risk.Medium;
        }
    }
}
