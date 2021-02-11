using System;
using System.Collections.Generic;
using System.Text;

namespace Ch04_Step3_MissingVoc
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}
