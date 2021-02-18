using System;

namespace Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Expecting one argument");
            }

            new Hello().SayHello(args[0]);
        }
    }
}
