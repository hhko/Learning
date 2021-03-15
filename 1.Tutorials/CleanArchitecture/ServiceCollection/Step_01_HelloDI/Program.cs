using Microsoft.Extensions.DependencyInjection;
using System;

namespace Step_01_DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            //
            // 의존성을 등록한다.
            //
            // <인터페이스, 구현> 
            // IServiceCollection AddTransient<TService, TImplementation>()
            services.AddTransient<IGreeting, Hello>();
            
            // <구현>
            // IServiceCollection AddTransient<TService>()
            services.AddTransient<ConsoleApp>();

            var provider =  services.BuildServiceProvider();

            // 
            // 의존성을 생성자에 주입하여 요청한 서비스(객체)를 생성한다.
            //
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
