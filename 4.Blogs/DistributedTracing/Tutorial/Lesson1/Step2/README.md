# Lesson 1 - **Step 2**

## 목표
- 로그(Microsoft.Extensions.Logging)을 출력한다.

## 배움
- dotnet 패키지 참조 명령어
  - dotnet add package
  - dotnet remove package
- Microsoft.Extensions.Logging 로그 출력
  - ```ILoggerFactory```
  - ```ILogger<T>```
- C# 8.0 using 선언
  - using var x = ...;

## 따라하기
1. .NET Core 프로젝트 만들기
   ```shell
    C:\DistributedTracing\Tutorial> dotnet new console -o .\Lesson1\Step2          // Console 프로젝트 만들기
    C:\DistributedTracing\Tutorial> dotnet sln add .\Lesson1\Step2\                // Step2 프로젝트 추가하기

    //
    // 프로젝트 참조 추가하기
    //
    // 1. 솔루션 폴더 위치에서
    C:\DistributedTracing\Tutorial> dotnet add .\Lesson1\Step2\ package Microsoft.Extensions.Logging.Console
    // 2. 프로젝트 폴더 위치에서
    C:\DistributedTracing\Tutorial\Lesson1\Step2> dotnet add package Microsoft.Extensions.Logging.Console

    C:\DistributedTracing\Tutorial> dotnet build                                   // 솔루션 빌드하기
    C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson1\Step2\ Foo      // Step2 프로젝트 실행하기
    info: Step2.Hello[0]
      Hello, Foo!
   ```
1. Microsoft.Extensions.Logging 로그 출력하기
   - [로그 팩토리(```ILoggerFactory```)](https://docs.microsoft.com/ko-kr/dotnet/api/microsoft.extensions.logging.iloggerfactory?view=dotnet-plat-ext-3.1)
     ```cs
     using (ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
     ``` 
   - [로거(```ILogger<T>```)](https://docs.microsoft.com/ko-kr/dotnet/api/microsoft.extensions.logging.ilogger-1?view=dotnet-plat-ext-3.1)
     ```cs
      public class Hello
      {
         private readonly ILogger<Hello> _logger;

         public Hello(ILoggerFactory loggerFactory)
         {
               _logger = loggerFactory.CreateLogger<Hello>();
         }
     ```
1. C# 8.0 using 선언하기
   - C# 8.0 언어 버전을 지정한다.
     ```xml
      <PropertyGroup>
        <LagVersion>8.0</LagVersion>
      </PropertyGroup>
     ```
   - using 선언(declation, C# 8.0) vs. using 문(statement)
     ```cs
	 using 선언(declation, C# 8.0)
     using var file = new System.IO.StreamWriter("WriteLines2.txt");
	 
     // vs.
	 
	 // using 문(statement)
     using (var file = new System.IO.StreamWriter("WriteLines2.txt")) { ... }
     ```
1. dotnet 패키지 명령어
   - dotnet add: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-add-package)
     - 형식: ```dotnet add [<PROJECT>] package <PACKAGE_NAME> [-f|--framework] [--package-directory] [-v|--version]
     - 예: dotnet add [프로젝트 폴더] add 
       - 최신 버전 참조하기
         - dotnet add package Newtonsoft.Json
       - 특정 버전 참조하기
         - dotnet add package Newtonsoft.Json -v 12.0.3
   - dotnet remove: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-remove-package)
   - dotnet list: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-list-package)
   - 패키지 저장 경로
     - Windows: %userprofile%\.nuget\packages
     - macOS, Linux: ~/.nuget/packages