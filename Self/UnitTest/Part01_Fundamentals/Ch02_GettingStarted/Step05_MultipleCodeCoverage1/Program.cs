using System;
using System.Diagnostics.CodeAnalysis;

namespace Step05_MultipleCodeCoverage1
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Console.WriteLine(c1.Method());
        }
    }
}
