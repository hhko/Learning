using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // 설정
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // 로그
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            // 통합 : 설정, 로그, 의존성
            var host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                    {
                        // 의존성 등록
                        services.AddTransient<IGreetingService, GreetingService>(); 
                    })
                .UseSerilog()
                .Build();

            // 객체 생성 : 의존성 주입
            var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
            svc.Run();

            //// Case 1. 
            //var case1 = new GreetingService(new NullLogger<GreetingService>(), null);
            //case1.Run();

            //// Case 2.
            //var services = new ServiceCollection()
            //    .AddLogging(config => config.AddConsole())      // can add any logger(s)
            //    .BuildServiceProvider();

            //using (var loggerFactory = services.GetRequiredService<ILoggerFactory>())
            //{
            //    var case2 = new GreetingService(loggerFactory.CreateLogger<GreetingService>(), null);
            //    case2.Run();
            //    //Assert.AreEqual(3, result);
            //}
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder
                // 설정 파일 기본 경로
                .SetBasePath(Directory.GetCurrentDirectory())
                // 설정 파일
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddJsonFile(
                    path: $"appsettings.{Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "production"}.json",
                    optional: true)
                // 환경 변수
                .AddEnvironmentVariables();
        }
    }
}
