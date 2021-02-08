using System;

namespace Null_02_ProducerPerspective
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
            Console.WriteLine(user.Name);
        }
    }
}
