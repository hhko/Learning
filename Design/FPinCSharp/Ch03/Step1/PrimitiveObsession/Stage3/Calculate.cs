using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace PrimitiveObsession.Stage3
{
    public enum Risk { Low, Medium, High }

    public class Calculate
    {
        [Pure]
        public static Risk CalculateRiskProfile(Age age)
        {
            return (age.Value < 60)
                ? Risk.Low
                : Risk.Medium;
        }
    }

    public struct Age
    {
        public int Value { get; }

        public Age(int value)
        {
            if (!IsValid(value))
                throw new ArgumentException($"{value} is not valid age");

            Value = value;
        }

        [Pure]
        private static bool IsValid(int age) =>
            0 <= age && age < 120;
    }
}
