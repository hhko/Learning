using System;
using System.Collections.Generic;
using System.Text;

namespace WhyNotVoid.Stage2
{
    // Unit은 데이터가 없음(the absence of data)을 나타낸다.

    using Unit = System.ValueTuple;
    using static F;

    public static partial class F
    {
        public static Unit Unit() => default(Unit);
    }

    public static class ActionExt
    {
        // 매개변수가 0개이고 반환 값이 없을 때(void)
        public static Func<Unit> ToFunc(this Action action) =>
            () =>
            {
                action();
                return Unit();
            };

        // 매개변수가 1개이고 반환 값이 없을 때(void)
        public static Func<T, Unit> ToFunc<T>(this Action<T> action) =>
            (t) =>
            {
                action(t);
                return Unit();
            };
    }
}
