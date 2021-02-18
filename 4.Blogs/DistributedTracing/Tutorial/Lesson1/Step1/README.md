# Lesson 1 - **Step 1**

## 목표
- .NET Core Console 프로그램을 개발한다.

## 배움
- dotnet 명령어를 이용하여 솔루션과 프로젝트를 만든다. 
  - dotnet new sln
  - dotnet new console
  - dotnet sln add
- Pure 함수를 정의한다.
  - [Pure]

## 따라하기
1. .NET Core 프로젝트 만들기
   ```shell
    C:\DistributedTracing\Tutorial> dotnet new sln -n Tutorial                     // 솔루션 파일 만들기
    C:\DistributedTracing\Tutorial> dotnet new console -o .\Lesson1\Step1          // Console 프로젝트 만들기
    C:\DistributedTracing\Tutorial> dotnet sln add .\Lesson1\Step1\                // Step1 프로젝트 추가하기
    C:\DistributedTracing\Tutorial> dotnet build                                   // 솔루션 빌드하기
    C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson1\Step1\ Foo      // Step1 프로젝트 실행하기
    Hello, Foo!
   ```
1. 순수 함수 구현하기
   - Pure와 Impure 함수를 구분한다(Pure 함수에는 [Pure] 속성을 명시한다).
   - 메시지를 Console에 출력한다.
     ```cs
        public class Hello
        {
            public void SayHello(string helloTo)
            {
                var msg = GreetingFor(helloTo);
                Console.WriteLine(GreetingFor(msg));
            }

            [Pure]
            private string GreetingFor(string helloTo)
            {
                return $"Hello, {helloTo}!";
            }
        }
     ```
1. dotnet 명령어
   - dotnet new: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-new?tabs=netcore22)
     - 형식: ```dotnet new <TEMPLATE> [-n|--name] [-o|--output] [-lang|--language]```
     - 예: dotnet new [sln | console] -n 이름 -o 경로 -lang [C# | F#]
       - 솔루션 만들기
       - 콘솔 프로젝트 만들기
   - dotnet sln: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-sln)
     - 형식: ```dotnet sln [<SOLUTION_FILE>] [command]```
     - 예: dotnet sln [솔루션 파일] {add | remove | list} [프로젝트 경로]
       - 프로젝트 추가하기
         - dotnet sln todo.sln add todo-app/todo-app.csproj
       - 여러 프로젝트 추가하기
         - dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj
         - dotnet sln todo.sln add **/*.csproj
   - dotnet build: [링크](https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet-build), [Framework 링크](https://docs.microsoft.com/ko-kr/dotnet/standard/frameworks)
     - 형식: ```dotnet build [<PROJECT>|<SOLUTION>] [-c|--configuration] [-f|--framework] [-o|--output]```
     - 예: dotnet build [솔루션 파일 | 프로젝트 파일] -c Release -f netcoreapp3.1
       - 출력 경로: ./bin/<configuration>/<framework>/
         - ./bin/Debug/netcoreapp3.1/
       - 솔루션 릴리즈 빌드하기
         - dotnet build --configuration Release
