using System;
using System.Collections.Generic;
using System.Text;

namespace Null_01_ComsumerPerspective
{
    public class User
    {
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
