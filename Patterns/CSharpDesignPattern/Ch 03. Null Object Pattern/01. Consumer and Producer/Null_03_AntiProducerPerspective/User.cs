using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_AntiProducerPerspective
{
    public class User : IUser
    {
        //
        // 문제: 소비자는 Null을 확인해야 한다(Null Object Anit-Pattern).
        //
        public bool IsNull => false;

        public string Name { get; private set; }

        public User(string name)
        {
            Name = name;
        }

        public void IncrementSessionTicket()
        {
            Console.WriteLine("User");
        }
    }
}
