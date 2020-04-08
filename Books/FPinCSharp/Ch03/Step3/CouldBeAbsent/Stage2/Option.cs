using System;
using System.Collections.Generic;
using System.Text;

namespace CouldBeAbsent.Stage2
{
    using Unit = System.ValueTuple;
    using static F;

    public static partial class F
    {
        public static Unit Unit() => 
            default(Unit);

        public static Option.None None =>
            Option.None.Default;

        // 반환 타입을 "Option.Some<T>"에서 "Option<T>"으로 변경한다.
        // - 변경 전
        //   public static Option.Some<T> Some<T>(T value) =>
        // - 변경 후
        //   public static Option<T> Some<T>(T value) =>
        // 질문?
        // - Option.Some<T> 타입이 Option<T> 타입으로 변환(?)할 수 있나?
        public static Option<T> Some<T>(T value) =>
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

    public struct Option<T>
    {
        private readonly bool _isSome;
        private readonly T _value;

        private Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _) =>
            new Option<T>();

        public static implicit operator Option<T>(Option.Some<T> some) =>
            new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) =>
            value == null 
            ? None              // F.None
            : Some(value);      // F.Some

        public R Match<R>(Func<R> None, Func<T, R> Some) =>
            _isSome
            ? Some(_value)
            : None();
    }
}
