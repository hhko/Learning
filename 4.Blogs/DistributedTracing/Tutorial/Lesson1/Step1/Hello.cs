using System;
using System.Diagnostics.Contracts;

namespace Step1
{
    public class Hello
    {
        public void SayHello(string helloTo)
        {
            var msg = GreetingFor(helloTo);
            Console.WriteLine(GreetingFor(msg));
        }

        [Pure]
        private string GreetingFor(string helloTo)
        {
            return $"Hello, {helloTo}!";
        }
    }
}