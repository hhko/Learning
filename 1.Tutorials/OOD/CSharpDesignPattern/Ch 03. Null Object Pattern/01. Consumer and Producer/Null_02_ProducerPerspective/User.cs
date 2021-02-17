using System;
using System.Collections.Generic;
using System.Text;

namespace Null_02_ProducerPerspective
{
    public class User : IUser
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
