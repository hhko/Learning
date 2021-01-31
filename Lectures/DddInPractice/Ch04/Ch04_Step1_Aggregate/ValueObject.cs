using System;
using System.Collections.Generic;
using System.Text;

namespace Ch04_Step1_Aggregate
{
    public abstract class ValueObject<T> 
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            //
            // Structual equality을 구현한다.
            //
            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
    }
}
