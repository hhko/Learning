using System;

namespace Step01_Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine($"Hello UnitTest : {calc.Add(1, 6)}");
        }
    }
}
