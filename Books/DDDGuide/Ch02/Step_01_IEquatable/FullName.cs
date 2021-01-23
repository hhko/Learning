using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_01_IEquatable
{
    //
    // 비교 호출 순서
    //   1. IEquatable<T>.Equals(T)
    //   2. bool Equals(object obj)
    //
    // https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1?view=net-5.0
    // For a value type, 
    //   you should always implement IEquatable<T> and override Equals(Object) for better performance. 
    //   Equals(Object) boxes value types and relies on reflection to compare two values for equality. 
    //
    public class FullName : IEquatable<FullName>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public FullName(string firstName, string lastName)
        {
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
    }
}
