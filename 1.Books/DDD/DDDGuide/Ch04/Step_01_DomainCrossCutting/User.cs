using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Step_01_DomainCrossCutting
{
    public class User : IEquatable<User>
    {
        public UserId Id { get; private set; }
        public UserName Name { get; private set; }

        public User(UserName name) 
            : this(new UserId(Guid.NewGuid().ToString()), name)
        {
        }

        public User(UserId id, UserName name)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Id = id;
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

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public void ChangeUserName(UserName name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
