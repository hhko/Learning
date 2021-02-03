using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_01_Identity
{
    public class User : IEquatable<User>
    {
        private readonly UserId _id;
        public string Name { get; private set; }

        public User(UserId id, string name)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            _id = id;
            ChangeUserName(name);
        }

        public void ChangeUserName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (name.Length < 3)
                throw new ArgumentException("사용자 이름은 3글자 이상이어야 함", nameof(name));

            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((User)obj);
        }

        public bool Equals([AllowNull] User other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return _id.Equals(other._id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }
}
