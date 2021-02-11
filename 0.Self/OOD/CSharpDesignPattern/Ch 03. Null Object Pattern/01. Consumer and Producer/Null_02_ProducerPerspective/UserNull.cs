using System;
using System.Collections.Generic;
using System.Text;

namespace Null_02_ProducerPerspective
{
    public class UserNull : IUser
    {
        //
        // 해결: Null일 때 기본값을 직접 지정할 수 있다(Null Object Pattern).
        //    (string 기본값은 null이다.)
        //
        public string Name => "홍길동";

        public void IncrementSessionTicket()
        {
            Console.WriteLine("UserNull");
        }
    }
}
