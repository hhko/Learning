using System;
using System.Collections.Generic;
using System.Text;

namespace Null_02_ProducerPerspective
{
    public class UserRepository
    {
        public UserRepository()
        {
        }

        public IUser GetById(string id)
        {
            // ...

            //
            // 해결: Null 처리는 생산자가 책임 진다(소비자는 Null을 확인하지 않는다).
            //
            //return null;
            return new UserNull();
        }
    }
}
