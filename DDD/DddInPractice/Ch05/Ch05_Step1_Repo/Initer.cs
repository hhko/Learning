using System;
using System.Collections.Generic;
using System.Text;

namespace Ch05_Step1_Repo
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}
