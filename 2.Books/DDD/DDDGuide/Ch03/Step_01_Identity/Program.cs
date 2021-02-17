using System;

namespace Step_01_Identity
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User(new UserId("1"), "고길동");
            var user2 = new User(new UserId("2"), "고길동");

            if (user1.Equals(user2))
            {
                Console.WriteLine("동일한 사람자임");
            }
            else
            {
                Console.WriteLine("서로 다른 사용자임");
            }
        }
    }
}
