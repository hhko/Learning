﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ch06_Step2_Atm.Utils
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}