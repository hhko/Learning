using System;
using System.Diagnostics.CodeAnalysis;

namespace ChallengingTheObjectOrientedMindset 
{
    public sealed class Date : IEquatable<Date>, IComparable<DateTime> 
    {
        private DateTime Value { get; }

        public Date (int year, int month, int day) 
        {
            Value = new DateTime (year, month, day);
        }

        public int CompareTo ([AllowNull] DateTime other) =>
            Value.CompareTo (other);

        public override bool Equals (object obj) 
        {
            if (ReferenceEquals (null, obj))
                return false;

            if (ReferenceEquals (this, obj))
                return true;

            if (obj.GetType () != GetType ())
                return false;

            return Equals ((Date) obj);
        }

        public bool Equals ([AllowNull] Date other) 
        {
            if (ReferenceEquals (null, other))
                return false;

            if (ReferenceEquals (this, other))
                return true;

            return Value.Equals (other.Value);
        }

        public override int GetHashCode () =>
            Value.GetHashCode ();

        public static bool operator == (Date a, Date b) =>
            (ReferenceEquals (a, null) && ReferenceEquals (b, null)) ||
            (!ReferenceEquals (a, null) && a.Equals (b));

        public static bool operator != (Date a, Date b) =>
            !(a == b);
    }
}