using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExplicitInterfaces
{
    public class Foo : IA, IB, IC
    {
        // Implement IA interface explicitly
        int IA.Run()
        {
            Console.WriteLine("IA.Run");
            return 1;
        }

        // Implement IA interface explicitly
        int IB.Run()
        {
            Console.WriteLine("IB.Run");
            return 2;
        }

        // Implement IA interface explicitly
        int IC.Run()
        {
            Console.WriteLine("IC.Run");
            return 3;
        }

        //public int Run()
        //{
        //    return 2019;
        //}
    }
}
