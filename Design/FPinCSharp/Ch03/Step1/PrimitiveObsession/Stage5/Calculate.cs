using LaYumba.Functional;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using static LaYumba.Functional.F;

namespace PrimitiveObsession.Stage5
{
    public enum Risk { Low, Medium, High }

    public class Calculate
    {
        [Pure]
        public static Risk CalculateRiskProfile(Option<Age> age)
        {
            // 유효성 검사가 실패하면 기본 값으로 처리한다.
            return age.Match(
                None: () => Risk.Low,   // 기본 값
                Some: _ => (_ < 60) ? Risk.Low : Risk.Medium);
        }
    }

    public struct Age
    {
        private int Value { get; }

        [Pure]
        private Age(int value)
        {
            Value = value;
        }

        // 유효성 검사가 실패하면 None으로 처리한다.
        public static Option<Age> Of(int age) =>
            IsValid(age)
            ? Some(new Age(age))
            : None;

        [Pure]
        private static bool IsValid(int age) =>
            0 <= age && age < 120;

        [Pure]
        public static bool operator <(Age l, Age r) =>
            l.Value < r.Value;

        [Pure]
        public static bool operator >(Age l, Age r) =>
            l.Value > r.Value;

        [Pure]
        public static bool operator <(Age l, int r) =>
            l < new Age(r);

        [Pure]
        public static bool operator >(Age l, int r) =>
            l > new Age(r);
    }
}
