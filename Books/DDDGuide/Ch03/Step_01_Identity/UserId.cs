using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_01_Identity
{
    public class UserId : IEquatable<UserId>
    {
        private string _value;

        public UserId(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((UserId)obj);
        }

        public bool Equals([AllowNull] UserId other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(_value, other._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }
    }
}
