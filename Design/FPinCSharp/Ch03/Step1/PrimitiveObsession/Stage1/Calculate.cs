using System;
using System.Collections.Generic;
using System.Text;

namespace PrimitiveObsession.Stage1
{
    public enum Risk { Low, Medium, High }

    public class Calculate
    {
        public static Risk CalculateRiskProfile(dynamic age) =>
            (age < 60)
                ? Risk.Low
                : Risk.Medium;
    }
}
