using System;
using System.Collections.Generic;
using System.Text;

namespace Ch07_Step1_DomainEvent.Utils
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}
