using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace WhyNotVoid.Stage1
{
    public static class Instrumentation
    {
        public static T Time<T>(string op, Func<T> f)
        {
            var sw = new Stopwatch();
            sw.Start();

            T t = f();

            sw.Stop();
            WriteLine($"{op} took {sw.ElapsedMilliseconds}ms");

            return t;
        }

        // - 문제점: Func<T>와 Action을 제외한 모든 코드가 중복이다.
        public static void Time(string op, Action f)
        {
            var sw = new Stopwatch();
            sw.Start();

            f();

            sw.Stop();
            WriteLine($"{op} took {sw.ElapsedMilliseconds}ms");
        }
    }
}
