using System;
using System.Collections.Generic;
using System.Text;

namespace Step_01_Repository
{
    public interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        User Find(UserName name);
    }
}
