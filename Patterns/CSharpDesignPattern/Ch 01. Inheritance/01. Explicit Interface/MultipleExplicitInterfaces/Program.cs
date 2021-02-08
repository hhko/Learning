using System;

namespace MultipleExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IA a = new Foo();
            a.Run();

            IB b = new Foo();
            b.Run();

            IC c = new Foo();
            c.Run();

            //
            //
            //
            //Foo f = new Foo();
            //f.Run();
        }
    }
}
