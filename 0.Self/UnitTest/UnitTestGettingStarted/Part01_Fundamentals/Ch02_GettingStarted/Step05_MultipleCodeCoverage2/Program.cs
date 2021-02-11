using System;
using System.Diagnostics.CodeAnalysis;

namespace Step05_MultipleCodeCoverage2
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Class2 c2 = new Class2();
            Console.WriteLine(c2.Method());
        }
    }
}
