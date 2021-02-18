using System;
using System.Diagnostics.CodeAnalysis;

namespace ChallengingTheObjectOrientedMindset 
{
    public sealed class Month : IEquatable<Month>, IComparable<DateTime> 
    {
        private DateTime Value { get; }

        public Month (int year, int month) 
        {
            Value = new DateTime (year, month, 1);
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

            return Equals ((Month) obj);
        }

        public bool Equals ([AllowNull] Month other) 
        {
            if (ReferenceEquals (null, other))
                return false;

            if (ReferenceEquals (this, other))
                return true;

            return Value.Equals (other.Value);
        }

        public override int GetHashCode () =>
            Value.GetHashCode ();

        public static bool operator == (Month a, Month b) =>
            (ReferenceEquals (a, null) && ReferenceEquals (b, null)) ||
            (!ReferenceEquals (a, null) && a.Equals (b));

        public static bool operator != (Month a, Month b) =>
            !(a == b);
    }
}