using System;

namespace Null_03_AntiProducerPerspective
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            IUser user = userRepository.GetById("xyz");

            //
            // 해결: 소비자는 Null을 확인하지 않는다(Null Object Pattern).
            //
            user.IncrementSessionTicket();

            // vs.

            //
            // 문제: 소비자는 Null을 확인해야 한다(Null Object Anit-Pattern).
            //
            string name = !user.IsNull
                ? user.Name
                : "알 수 없음";
        }
    }
}
