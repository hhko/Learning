using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace WhyNotVoid.Stage2
{
    using Unit = System.ValueTuple;

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
        // - 개선점: void 타입을 Unit으로 변경하여 Action을 Func을 구분하지 않는다(일관성consistency을 제공한다).
        //
        // - 문제점: 모든 Action을 Func으로 변환 시켜야 한다.
        public static void Time(string op, Action f) =>
            Time<Unit>(op, f.ToFunc());
    }
}
