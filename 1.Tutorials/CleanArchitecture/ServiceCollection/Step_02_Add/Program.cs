using Microsoft.Extensions.DependencyInjection;
using System;

namespace Step_02_Duplicated
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IGreeting, Hello>();

            //
            // 가장 마지막에 추가한 것이 우선순위가 높다.
            //
            services.AddTransient<IGreeting, Hi>();     

            services.AddTransient<ConsoleApp>();
            var provider = services.BuildServiceProvider();

            var app = provider.GetRequiredService<ConsoleApp>();
            app.Print();
        }
    }

    public interface IGreeting
    {
        string Message { get; }
    }

    public class Hello : IGreeting
    {
        public string Message => "Hello";
    }

    public class Hi : IGreeting
    {
        public string Message => "Hi";
    }

    public class ConsoleApp
    {
        private readonly IGreeting _greeting;

        public ConsoleApp(IGreeting greeting)
        {
            _greeting = greeting;
        }

        public void Print()
        {
            Console.WriteLine(_greeting.Message);
        }
    }
}
