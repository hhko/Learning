using System;
using System.Diagnostics.CodeAnalysis;

namespace Step04_CodeCoverage
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine($"Hello UnitTest : {calc.Add(1, 6)}");
        }
    }
}
