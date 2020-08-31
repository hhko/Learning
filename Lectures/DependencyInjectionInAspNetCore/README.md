# Dependency Injection in ASP.NET Core

## 자료
- [Dependency Injection in ASP.NET Core](https://app.pluralsight.com/library/courses/aspdotnet-core-dependency-injection/exercise-files)

## 목차
1. Registering Your First Service
   - 1.1 Introduction and Overview
   - 1.2 Why Use Dependency Injection?
   - 1.3 Coding to Interfaces
   - 1.4 Inverting Control with Constructor Injection
   - 1.5 Registering Your First Service
   - 1.6 Benefits of Dependency Injection
   - 1.7 Review
1. The Microsoft Dependency Injection Container
   - 2.1 Introduction and Overview
   - 2.2 The Microsoft Dependency Injection Container
   - 2.3 What to Register with the D.I. Container
   - 2.4 Accessing Configuration from a Controller
   - 2.5 Service Lifetimes
   - 2.6 Transient Services
   - 2.7 Singleton Services
   - 2.8 Scoped Services
   - 2.9 Avoiding Captive Dependencies
   - 2.10 Review
1. Registering More Complex Services
   - 3.1 Introduction and Overview
   - 3.2 Introducing the Tennis Booking Application
   - 3.3 Service Descriptors
   - 3.4 Add vs. TryAdd
   - 3.5 Registering an Interface Multiple Times
   - 3.6 Replacing and Removing Registrations
   - 3.7 Registering Multiple Implementations of an Interface
   - 3.8 Improving Multiple Implementations with TryAddEnumerable
   - 3.9 Implementation Factories
   - 3.10 Registering an Implementation against Multiple Service Types
   - 3.11 Registering Open Generics
   - 3.12 Clean Code Using Extension Methods
   - 3.13 Review
1. Injecting and Resolving Dependencies
   - 4.1 Introduction and Overview
   - 4.2 Service Resolution Mechanisms
   - 4.3 Constructor Injection
   - 4.4 Action Injection
   - 4.5 Injecting Services into Middleware
   - 4.6 Injecting Services into Razor Views
   - 4.7 Creating and Using Scopes
   - 4.8 Review
1. Beyond the Built-in Container
   - 5.1 Introduction and Overview
   - 5.2 Introducing and Installing Scrutor
   - 5.3 Assembly Scanning with Scrutor
   - 5.4 Applying the Decorator Pattern with Scrutor
   - 5.5 Replacing the Built-in Dependency Injection Container
   - 5.6 Review

## 1. Registering Your First Service
### 1.1 Introduction and Overview
- 개발 환경
  - ASP.NET Core 2.2 : 2018년 12월(현재)
    - ASP.NET Core 1.0 : 2016년 6월
  - .NET Core 2.2 SDK
  - Visual Studio 2017 15.9.x 이상

### 1.2 Why Use Dependency Injection?
- DI : Dependency Injection
  - Inversion of Control
  - Dependency Inversion Principle
- ASP.NET 의존성
  - Logging
  - Configuration
  - Hosting
  - Dependency Injection 
- 구체화 의존성의 문제점
  - Concreate 클래스(구현)에 의존한다.
  - 행위(클래스의 구현)를 변화 시킬 수 없다.
    - 행위를 변화 시킬 수 없다(단위 테스트가 불가능하다).

### 1.3 Coding to Interfaces
- Robert C. Martin
  - High-level modules should not depend on low-level modules. Both should depend on abstractions.
  - Abstractions should not depend upon details. Detials should depend upon abstraction.
- 인터페이스를 만든다.
  ```
  public interface IWeatherForecaster
  public class WeatherForecaster : IWeatherForecaster
  public class AmazingWeatherForecaster : IWeatherForecaster
  ```

### 1.4 Inverting Control with Constructor Injection
- With constructor injection we define the list of required dependencies as parameters of the constructor for a class
- 클래스에서 필요한 모든 의존성을 생성자를 통해서 전달 받는다.
- `readonly` 키워드를 이용하여 주입된 의존성이 변경될 가능성을 제거시킨다.
  ```cs
  private readonly ILogger<HomeController> _logger;
  private readonly IWeatherForecaster _weatherForecaster;

  public HomeController(
      ILogger<HomeController> logger,
      IWeatherForecaster weatherForecaster)  // 의존성 주입
  {
      _logger = logger;
      _weatherForecaster = weatherForecaster;
  }
  ```
- 의존성 주입을 통해 객체 생성 책임을 제거시킨다.
  ```cs
  //var weatherForecaster = new WeatherForecaster();
  //var currentWeather = weatherForecaster.GetCurrentWeather();
  var currentWeather = _weatherForecaster.GetCurrentWeather();
  ```
- 생성자를 통한 의존성 주입으로 인해 런타임 에러가 발생한다.
  ```
  An unhandled exception occurred while processing the request.
   InvalidOperationException: 
        Unable to resolve service 
        for type 'WebApp.Services.IWeatherForecaster' 
        while attempting to activate 'WebApp.Controllers.HomeController'.
   Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(
        IServiceProvider sp, 
        Type type, 
        Type requiredBy, 
        bool isDefaultParameterRequired)
  ```
### 1.5 Registering Your First Service
- IServiceCollection
  - 의존성(서비스)을 등록하는 역학을 갖는다.
  - 정의된 메서드가 하나도 없다.
    ```cs
    public interface IServiceCollection 
        : ICollection<ServiceDescriptor>
        , IEnumerable<ServiceDescriptor>
        , IEnumerable
        , IList<ServiceDescriptor>
    {
    }
    ```
  - 관련 기능은 모두 확장 메서드로 제공한다(Microsoft.Extensions.DependencyInjection 패키지).
    ```cs
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class ServiceCollectionServiceExtensions
        {
            public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services)
                where TService : class
                where TImplementation : class, TService;
        }
    }
    ```

### 1.6 Benefits of Dependency Injection
- DI 장점
  - Promotes loose coupling of components
    - 관련된 여러 코드를 변경시켜야 한다.  
      vs. 관련된 코드 한 곳을 변경시킨다(지역성)  
  - Promotes logical abstraction of components
    - 코드를 변경 시킨다.  
      vs. 코드를 변경 시키지 않는다.  
  - Supports unit testing
    - 경우의 수를 코드화할 수 없다.  
      vs. 경우의 수를 코드화할 수 있다.  
  - Clearner, more readable code
- 단위 테스트
  - 경우의 수를 코드화할 수 있다.
    - WeatherCondition.Sun
    - WeatherCondition.Rain
  - Moq 패키지를 이용하여 경우의 수를 코드화한다. 
    ```cs
    [Fact]
    public void ReturnsExpectedViewModel_WhenWeatherIsSun()
    {
        // Arrange
        var weatherForecaster = new Mock<IWeatherForecaster>();
        weatherForecaster
            .Setup(x => x.GetCurrentWeather())
            .Returns(new WeatherResult
            {
                WeatherCondition = WeatherCondition.Sun
            });
    
        var sut = new HomeController(null, weatherForecaster.Object);
        ...
    }
    
    [Fact]
    public void ReturnsExpectedViewModel_WhenWeatherIsRain()
    {
        // Arrange
        var weatherForecaster = new Mock<IWeatherForecaster>();
        weatherForecaster
            .Setup(x => x.GetCurrentWeather())
            .Returns(new WeatherResult
            {
                WeatherCondition = WeatherCondition.Rain
            });
    
        var sut = new HomeController(null, weatherForecaster.Object);
        ...
    }
    ```

### 1.7 Review
- 의존성 식별하기
- 의존성을 추상화하기(Dependency Inversion Principle) : 인터페이스 만들기
- 의존성을 주입받기 : 생성자
- 의존성을 주입하기(Dependency Injection) : IServiceCollection 인터페이스, Startup 클래스
- 경우의 수 단위 테스트하기 : Moq 패키지

<br/>

## 2. The Microsoft Dependency Injection Container
### 2.1 Introduction and Overview
- Dependency Injection Container의 Lifecycle 관리 방법을 이해한다.

### 2.2 The Microsoft Dependency Injection Container
- DI Container
  - HostingEnvironment
  - MVC
  - ApplicationLifetime
  - Routing
  - Logging
  - Configuration
- Asp.NET Core and DI
  - Web  
    -> Http Request    
    -> Controller Activation(ActivatorUtilities)  
    -> Resolve Services(DI Container)  
- namespace Microsoft.Extensions.DependencyInjection
- Dependency Injection Container = Inversion of Control Container
- DI Container 주요 로직
  - Regiser : IServiceCollection
  - DI Container  
    - creating and disposing of instances of required services on demand  
    - maintaining them for a specified lifetime.  
  - Resolve : IServiceProvider

### 2.3 What to Register with the D.I. Container
- 의존성 식별하기
  - locate `new` keyword usage
    - 의존성인가? Yes이면 의존성을 주입 받는다.
  - 불순(Impure) 메서드
  - Primitive Types and Strings -> the strongly-typed option pattern
- 의존성 그래프를 그린다(계층 구조).

### 2.4 Accessing Configuration from a Controller
- IOption<T> : Primitive Types and Strings 의존성은 strongly-typed option 패턴으로 처리한다.
  ```cs
  // appsettings.json 파일
  {
    "Features": {
      "EnableWeatherForecast":  true
    }
  }

  // Startup.cs 파일
  services.Configure<FeaturesConfiguration>(Configuration.GetSection("Features"));

  // HomeController.cs 파일
  private readonly FeaturesConfiguration _featuresConfiguration;

  public HomeController( ...
      , IOptions<FeaturesConfiguration> options)
  {
      ...
      _featuresConfiguration = options.Value;
  }
  ```
- IOption<T> 인터페이스
  ```cs
  public interface IOptions<out TOptions> where TOptions : class, new()
  {
        TOptions Value { get; }
  }
  ```
- IOption<T> 인터페이스 단위 테스트
  - Case 1. Options.Create 메서드 이용
    ```cs  
    var options1 = Options.Create(new FeaturesConfiguration { EnableWeatherForecast = true });
    var sut = new HomeController(null, weatherForecaster.Object, options1);
    ```
  - Case 2. Mock 이용
    ```cs
    var options2 = new Mock<IOptions<FeaturesConfiguration>>();
    options2
        .Setup(x => x.Value)
        .Returns(new FeaturesConfiguration { EnableWeatherForecast = true });
    var sut2 = new HomeController(null, weatherForecaster.Object, options2.Object);
    ```
- `TODO: appsettings.json 파일을 이용한 단위테스트 방법은?`

### 2.5 Service Lifetimes
- Lifetimes
  - Transient : Created each time they are request
  - Singleton : Created once for the lifetime of the application
  - Scoped : Create once per request
- Guid를 이용한 예제
  - Guid 특징
    - 유일한 값
  - 2개 이상의 사용처
    - HomeController
    - CustomMiddleware
  - appsettings.json 변경
    ```
    "profiles": {
      "IIS Express": {
        "launchUrl": "",   // "launchUrl": "weatherforcast"
    ```
  - Startup.cs과 CustomMiddleware.cs 파일
    - `TODO:` [ASP.NET Core의 팩터리 기반 미들웨어 활성화](https://docs.microsoft.com/ko-kr/aspnet/core/fundamentals/middleware/extensibility?view=aspnetcore-3.1)
    ```cs
    app.UseMiddleware<CustomMiddleware>();

    public class CustomMiddleware
    {
        public async Task InvokeAsync(HttpContext context, GuidService guidService)
        { 
            ...
        }
    }
    ```
### 2.6 Transient Services
- Not required to be thread-safe
  - 매번 생성하기 때문에 메모리를 공유하지 않는다.
- Poentially less efficient
  - 성능 : 생성 시간, 해제 시간(가비지 컬렉터)
  - 메모리
- Easiest to reason about
- 예. GuidService 객체가 "2번 x 새로고침" 생성된다.
  ```CS
  services.AddTransient<GuidService>();

  // GuidService 객체 생성
  public async Task InvokeAsync(HttpContext context, GuidService guidService)

  // GuidService 객체 생성
  public HomeController(ILogger<HomeController> logger, GuidService guidService) 
  ```

### 2.7 Singleton Services
- Generally more performant
  - Allocates less objects
  - Reduces load on GC
- Must be thread-safe
- Suited to functional stateless services
- Consider frequency of use vs. Memory consumption
- 예. GuidService 객체가 1번만(새로고침과 무관) 생성된다.
  ```CS
  services.AddTransient<GuidService>();
  ```

### 2.8 Scoped Services
- 새로고침(Request) 단위로 새 인스턴스를 생성한다.
- 예. GuidServer 객체가 "1번 x 새로고침" 생성된다.
  ```cs
  services.AddScoped<GuidService>();
  ```
### 2.9 Avoiding Captive Dependencies
- `TODO: 전반적인 이해가 필요하다`
- A service should not depend on a service with a lifetime shorter than its own.
- 예.
  - Singleton 서비스가 Lifetime이 짧은 서비스에 의존해서는 안된다.
- Validate Scope 
  ```cs
  public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseDefaultServiceProvider(options =>
            {
                options.ValidateScopes = true;
            })
            ...
  ```

### 2.10 Review
- 의존성 식별하기
  - `new` 키워드 식별자는 후보자다.
  - 불순 함수는 의존성이다.
  - 수용해야할 변화의 범위는 의존성이다.
- DI Container Lifecycle 이해
  - Transient
  - Singleton
  - Scoped : 새로 고침 단위로 새 인스턴스 생성
- strongly-typed option 패턴
  - IOption<T>
  - Options.Create<T> 단위 테스트

<br/>

## 3. Registering More Complex Services
### 3.1 Introduction and Overview
### 3.2 Introducing the Tennis Booking Application
### 3.3 Service Descriptors
### 3.4 Add vs. TryAdd
### 3.5 Registering an Interface Multiple Times
### 3.6 Replacing and Removing Registrations
### 3.7 Registering Multiple Implementations of an Interface
### 3.8 Improving Multiple Implementations with TryAddEnumerable
### 3.9 Implementation Factories
### 3.10 Registering an Implementation against Multiple Service Types
### 3.11 Registering Open Generics
### 3.12 Clean Code Using Extension Methods
### 3.13 Review