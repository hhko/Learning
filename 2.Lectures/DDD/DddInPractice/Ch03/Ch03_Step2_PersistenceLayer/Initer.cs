﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03_Step2_PersistenceLayer
{
    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}