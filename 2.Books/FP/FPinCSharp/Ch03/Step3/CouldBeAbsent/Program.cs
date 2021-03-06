﻿using System;

namespace CouldBeAbsent
{
    using static Stage2.F;

    class Program
    {
        static void Main(string[] args)
        {
            // Stage 1: 불순 함수
            {
                Stage1.IndexerIdiosyncracy.Impure();
            }

            // Stage 2: 순수 함수
            {
                var firstName = Some("Enrico");
                var middleName = None;

                Stage2.Hello.Greet(None);
                Stage2.Hello.Greet(Some("John"));
            }
        }
    }
}
