using System;
using System.Diagnostics.CodeAnalysis;

namespace Step05_MultipleCodeCoverage3
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Class3 c3 = new Class3();
            Console.WriteLine(c3.Method());
        }
    }
}
