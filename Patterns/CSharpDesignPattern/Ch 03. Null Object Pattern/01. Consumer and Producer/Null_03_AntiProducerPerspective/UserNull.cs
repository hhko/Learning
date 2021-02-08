using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_AntiProducerPerspective
{
    public class UserNull : IUser
    {
        //
        // 문제: 소비자는 Null을 확인해야 한다(Null Object Anit-Pattern).
        //
        public bool IsNull => true;

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
