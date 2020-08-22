using System;

namespace Step02_FluentAssertion
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
