using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomLinqSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query #1.
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // The query variable can also be implicitly typed by using var
            IEnumerable<int> filteringQuery =
                from num in numbers
                select num;

            //numbers.Select

            //Foo f = new Foo();
            //var retFoo =
            //    from newFoo in f
            //    select newFoo;

        }
    }

    //public class Foo
    //{
    //    public static IEnumerable<TResult> Select<TSource, TResult>(Func<TSource, TResult> selector) 
    //    {
            
    //    }
    //}
}
