using System;

namespace Ch02
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = "Abc";
            bool b1 = char.IsHighSurrogate(name1[0]);

            string name2 = "한글";
            bool b2 = char.IsHighSurrogate(name2[0]);

            var x1 = new _03.Immutable.Student("xyz1");
            var x2 = _03.Immutable.Student.New("xyz2");
            var x3 = x2.With("abc");


            Console.WriteLine("Hello World!");
        }
    }
}
