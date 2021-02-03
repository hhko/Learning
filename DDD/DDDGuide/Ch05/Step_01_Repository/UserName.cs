using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_01_Repository
{
    public class UserName : IEquatable<UserName>
    {
        public string Value { get; }

        public UserName(string value)
        {
            if (value == null) 
                throw new ArgumentNullException(nameof(value));

            if (value.Length < 3) 
                throw new ArgumentException("사용자명은 3글자 이상이어야 함", nameof(value));

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((UserName)obj);
        }

        public bool Equals([AllowNull] UserName other)
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
