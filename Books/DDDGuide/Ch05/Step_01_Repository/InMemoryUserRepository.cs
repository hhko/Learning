using System;
using System.Collections.Generic;
using System.Text;

namespace Step_01_Repository
{
    public class InMemoryUserRepository : IUserRepository
    {
        public Dictionary<UserId, User> Store { get; } = new Dictionary<UserId, User>();

        public void Delete(User user)
        {
        }

        public User Find(UserName name)
        {
            foreach (var user in Store.Values)
            {
                if (user.Name.Equals(name))
                {
                    return Clone(user);
                }
            }

            return null;
        }

        public void Save(User user)
        {
            Store[user.Id] = Clone(user);
        }

        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }
    }
}
