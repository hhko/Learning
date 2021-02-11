// 목표: GreetingFor 순수 함수를 확장 함수로 만든다.
// - 함수를 연속하여 호출할 수 있다.

using System;
using System.Diagnostics.Contracts;
using static System.Console;

namespace ManagingSideEffects.Stage3
{
    public class PureComposition
    {
        public void SideEffects()
        {
            WriteLine("Enter your name:");

            // GreetingFor 함수를 연속 호출한다.
            var greet = ReadLine().GreetingFor();

            WriteLine(greet);
        }
    }

    public static class StringExt
    {
        [Pure]
        public static string GreetingFor(this string self) =>
            $"Hello {self}";
    }
}