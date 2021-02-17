using System;
using System.Collections.Generic;
using System.Text;

namespace Null_01_ComsumerPerspective
{
    public class UserRepository
    {
        public UserRepository()
        {
        }

        public User GetById(string id)
        {
            // ...

            //
            // 문제: Null 책임을 소비자에게 전달 시킨다.
            //
            return null;
        }
    }
}
