using System;
using System.Collections.Generic;
using System.Text;

namespace CouldBeAbsent.Stage2
{
    using Unit = System.ValueTuple;

    public static partial class F
    {
        public static Unit Unit() => default(Unit);

        public static Option.None None =>
            Option.None.Default;

        public static Option.Some<T> Some<T>(T value) =>
            new Option.Some<T>(value);
    }

    // Could be absent
    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(T));

                Value = value;
            }
        }

        // 문제점: C# 컴파일러는 "union types"을 제공하지 않는다.
        //interface Option<out T> { }
        //namespace Option
        //{
        //    // 컴파일러 실패(Error) 코드
        //    // public struct None : Option<T> { /* ... */ }
        //    //  - Error CS0246
        //    //  - The type or namespace name 'T' could not be found(are you missing a using directive or an assembly reference?)
        //    //
        //    // 컴파일러 성공 코드
        //    // public struct None<T> : Option<T> { /* ... */ }
        //
        //    public struct Some<T> : Option<T> { /* ... */ }
        //}
    }
}
