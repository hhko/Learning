using System;

namespace Ch02_Step3_EntityAndValueObject
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            //
            // Reference equality을 구현한다.
            //
            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //
            // Indentifier equality을 구현한다.
            //
            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            //
            // "==" 연산자는 두 매개변수 모두 NULL이 입력될 수 있다.
            //

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
