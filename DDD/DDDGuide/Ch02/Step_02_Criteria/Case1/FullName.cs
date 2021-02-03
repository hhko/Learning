using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Step_02_Criteria.Case1
{
    public class FullName : IEquatable<FullName>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public FullName(string firstName, string lastName)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));

            if (!ValidateName(firstName))
                throw new ArgumentException("허가되지 않은 문자가 사용됨", nameof(firstName));
            if (!ValidateName(LastName))
                throw new ArgumentException("허가되지 않은 문자가 사용됨", nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
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

        public bool Equals([AllowNull] FullName other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(FirstName, other.FirstName)
                && string.Equals(LastName, other.LastName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }

        private bool ValidateName(string value)
        {
            return Regex.IsMatch(value, $"^[a-zA-Z]+$");
        }
    }
}
