# .NET Core Console App with Dependency Injection, Logging, and Settings

- [.NET Core Console App with Dependency Injection, Logging, and Settings](https://www.youtube.com/watch?v=GAOCe-2nXqc)
  - 의존성 : IServiceCollection
  - 로그 : Serilog
  - 설정 : IConfiguration
  - 통합(의존성, 로그, 설정) : Host

## 프로젝트 기본 구성
1. .NET Core 프로젝트 
   - 템플릿 : Console App
   - 프로젝트 이름 : ConsoleUI
   - 솔루션 이름 : BetterConsoleApp
1. NuGet 패키지
   - Microsoft.Extensions.Hosting : 3.1.7
   - Serilog.Extensions.Hosting : 3.1.0
   - Serilog.Settings.Configuration : 3.1.0
   - Serilog.Sinks.Console : 3.1.1
1. 환경 파일
   - 파일 타입 : JSON
   - 파일 이름 : appsettings.json
   - 파일 속성 : Copy to Output Directory -> Copy always

## 설정
1. 기본 코드
   ```cs
   var builder = new ConfigurationBuilder();
   BuildConfig(builder);
   
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
   ```
1. 인터페이스 및 확장 메서드
   ```cs
   namespace Microsoft.Extensions.Configuration
   {
       public interface IConfigurationBuilder
       {
               IDictionary<string, object> Properties { get; }
               IList<IConfigurationSource> Sources { get; }
   
               IConfigurationBuilder Add(IConfigurationSource source);
               IConfigurationRoot Build();
       }
   
       public static class FileConfigurationExtensions
       {
           public static IConfigurationBuilder SetBasePath(this IConfigurationBuilder builder, string basePath);
       }
   
       public static class JsonConfigurationExtensions
       {
           public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange);
       }
   
       public static class EnvironmentVariablesExtensions
       {
           public static IConfigurationBuilder AddEnvironmentVariables(this IConfigurationBuilder configurationBuilder);
       }
   }
   ```
1. 기본 경로
1. 설정 파일 지정
   - 필수 유/무
     - 필수 : appsettings.json
     - 선택 : appsettings.production.json, 환경 변수
   - TODO Reload?
   - TODO 다중 파일 지정 가능?
1. 환경 변수

## 로그
1. 기본 코드
   ```cs
   Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(builder.Build())
       .Enrich.FromLogContext()
       .WriteTo.Console()
       .CreateLogger();
   ```
1. 확장 메서드
   ```cs
   namespace Serilog
   {
       public static class SerilogHostBuilderExtensions
       {
           public static IHostBuilder UseSerilog(this IHostBuilder builder, ILogger logger = null, bool dispose = false, LoggerProviderCollection providers = null);
       }
   }
   ```

## 의존성(통합)
1. 기본 코드
   ```cs
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
   ```
1. 확장 메서드
   ```
   namespace Microsoft.Extensions.Hosting
   {
       public interface IHostBuilder
       {
           IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate);
       }
   }
   ```

## 배움
1. 빌더 패턴
   - IConfigurationBuilder
   - I...Builder
1. 확장 메서드 설계 방법
   - 클래스 이름 : 책임 단위로 확장 메서드를 만든다.
   - 예.
     - FileConfigurationExtensions
     - JsonConfigurationExtensions
1. FileConfigurationExtensions 추가 기능 
   - 예외 처리 : SetFileLoadExceptionHandler, GetFileLoadExceptionHandler
     - FileLoadExceptionContext
   - Provider? : SetFileProvider, GetFileProvider
     - IFileProvider
1. Visual Studio 텍스트 에디터 옵션
   - Naming Style 
     - Naming Sytle Title : Underscore
     - Required Prefix : _
     - Capitalization : camal Case Name
   - Naming
     - Specification : Private or Internal Field 
     - Required Syste : Unerscore
     - Severity : Refactoring Only
1. 의존성 주입
   - 생성자
   - 예외 : 관련 모든 타입을 사전에 주입 시켜야 한다.
     ```
     System.InvalidOperationException
       HResult=0x80131509
       Message=A suitable constructor for type 'ConsoleUI.IGreetingService' could not be located. 
       Ensure the type is concrete and services are registered for all parameters of a public constructor.
       Source=Microsoft.Extensions.DependencyInjection.Abstractions
       StackTrace:
        at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance(IServiceProvider provider, Type instanceType, Object[] parameters)
        at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance[T](IServiceProvider provider, Object[] parameters)
        at ConsoleUI.Program.Main(String[] args) in C:\Users\Hyungho.Ko\source\repos\BetterConsoleApp\ConsoleUI\Program.cs:line 37
     ```