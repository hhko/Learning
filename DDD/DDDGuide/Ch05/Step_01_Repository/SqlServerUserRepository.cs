using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step_01_Repository
{
    public class SqlServerUserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public SqlServerUserRepository(UserDbContext context)
        {
            _context = context;
        }

        public void Delete(User user)
        {
        }

        public User Find(UserName name)
        {
            var target = _context
                .Users
                .FirstOrDefault(userData => userData.Name.Equals(name));

            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public void Save(User user)
        {
            var found = _context.Users.Find(user.Id.Value);

            if (found == null)
            {
                var data = ToDataModel(user);
                _context.Users.Add(data);
            }
            else
            {
                var data = Transfer(user, found);
                _context.Users.Update(data);
            }

            _context.SaveChanges();
        }

        private User ToModel(UserDataModel from)
        {
            return new User(
                new UserId(from.Id),
                new UserName(from.Name)
            );
        }

        private UserDataModel ToDataModel(User from)
        {
            return new UserDataModel
            {
                Id = from.Id.Value,
                Name = from.Name.Value,
            };
        }

        private UserDataModel Transfer(User from, UserDataModel model)
        {
            model.Id = from.Id.Value;
            model.Name = from.Name.Value; return model;
        }
    }
}
