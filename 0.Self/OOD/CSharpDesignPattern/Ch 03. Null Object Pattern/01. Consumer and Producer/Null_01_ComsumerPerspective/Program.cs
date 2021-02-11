using System;

namespace Null_01_ComsumerPerspective
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetById("xyz");

            //
            // 문제: 소비자는 Null을 확인해야 한다(Null Object Pattern).
            //
            if (user != null)
            {
                user.IncrementSessionTicket();
                Console.WriteLine(user.Name);
            }
        }
    }
}
