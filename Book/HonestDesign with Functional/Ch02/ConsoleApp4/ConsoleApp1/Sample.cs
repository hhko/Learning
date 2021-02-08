using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sample
    {
        [Benchmark(Baseline = true)]
        public void DoSomething()
        {

        }

        [Benchmark]
        [Interceptor]
        public void DoSomethingWith()
        {

        }

        [Benchmark]
        public void DoSomethingWithExplicit_alwaysNew()
        {
            Foo foo = new Foo();
            foo.OnEntry();
            foo.OnExit();
        }

        Foo _foo = new Foo();

        [Benchmark]
        public void DoSomethingWithExplicit_OnceNew()
        {
            _foo.OnEntry();
            _foo.OnExit();
        }

        [Benchmark]
        public void DoSomethingWithExplicitByAttribute()
        {
            LogAttribute attribute = (LogAttribute)Activator.CreateInstance(typeof(LogAttribute));

            attribute.OnEntry();
            attribute.OnExit();
        }
    }

    public class Foo
    {
        public void OnEntry()
        {

        }

        public void OnExit()
        {

        }
    }

    public class LogAttribute : Attribute
    {
        public void OnEntry()
        {

        }

        public void OnExit()
        {

        }
    }
}
