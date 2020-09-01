using System;

namespace Step03_RunWithoutVS
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
