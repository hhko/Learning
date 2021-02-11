using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Step_02_Criteria.Case2
{
    public class Name : IEquatable<Name>
    {
        public string Value { get; }

        public Name(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!Validate(value))
                throw new ArgumentException("허가되지 않은 문자가 사용됨", nameof(value));

            Value = value;
        }

        private bool Validate(string value)
        {
            return Regex.IsMatch(value, $"^[a-zA-Z]+$");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((FullName)obj);
        }

        public bool Equals([AllowNull] Name other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
