# .NET Core & Visual Studio Code

## 참고 자료
- dotnet 명령어 : https://docs.microsoft.com/ko-kr/dotnet/core/tools/dotnet?tabs=netcore21
- VSCode 문서: https://code.visualstudio.com/docs
- NuGet 폴더 관리: https://docs.microsoft.com/ko-kr/nuget/consume-packages/managing-the-global-packages-and-cache-folders
- 프레임워크명 : https://docs.microsoft.com/ko-kr/dotnet/standard/frameworks

## dotnet 명령어
- 버전: dotnet --version

### 솔루션
- 솔루션 만들기
  - 명령: dotnet new sln -n [솔루션명] -o [솔루션 경로]
  - 예제: dotnet new sln -n helloworld -o helloworld
- 프로젝트 만들기
  - 명령: 
    - dotnet new [템플릿] -n [프로젝트명] - o [프로젝트 경로] -f [프레임워크명] -lang [언어] --langVersion [언어 버전] 
    - dotnet new [console | classlib | xunit] -n helloworld - o helloworld -f netstandard2.1 -lang c# --langVersion 8.0
  - 예제:   
    - dotnet new classlib -n hellolib -o hellolib -f netstandard2.1 -lang c# --langVersion 8.0
    - dotnet new console -n hellolib -o hellolib -f netstandard2.1 -lang c# --langVersion 8.0
- 프로젝트 추가하기
  - 명령: dotnet sln [솔루션 파일] add [프로젝트 파일]
  - 예제: dotnet sln helloworld.sln add helloworld/helloworld.csproj  
- ~~TODO: 여러 프로젝트를 한번에 추가하기~~
  - ~~명령: dotnet sln [솔루션 파일] add [프로젝트 파일] N개~~
- 프로젝트 제거하기
  - 명령: dotnet sln [솔루션 파일] remove [프로젝트 파일]
  - 예제: dotnet sln helloworld.sln remove helloworld/helloworld.csproj 
- ~~TODO: 여러 프로젝트를 한번에 제거하기~~
  - ~~명령: dotnet sln [솔루션 파일] remove [프로젝트 파일] N개~~

### 참조
- 프로젝트 참조 추가하기
  - 1개
    - 명령: dotnet add [프로젝트 파일] reference [프로젝트 파일]
    - 예제: dotnet add ./helloworld/helloworld.csproj reference ./hellolib/hellolib.csproj  
  - N개
    - 명령: dotnet add [프로젝트 파일] reference [프로젝트 파일 조건]
    - 예제: dotnet add ./x1/x1.csproj reference ./hel*/hel*.csproj
- 프로젝트 참조 목록보기
  - 명령: dotnet list [프로젝트 파일] reference   
  - 예제: dotnet list ./helloworld/helloworld.csproj reference   
- 프로젝트  참조 제거하기
  - 1개
    - 명령: dotnet remove [프로젝트 파일] reference [프로젝트 파일]
    - 예제: dotnet remove ./helloworld/helloworld.csproj reference ./hellolib/hellolib.csproj
  - N개
    - 명령: dotnet remove [프로젝트 파일] reference [프로젝트 파일 조건]
    - 예제: dotnet remove ./x1/x1.csproj reference ./hel*/hel*.csproj	
- NuGet 패키지 참조 추가하기	
  - 1개
    - 명령: dotnet add [프로젝트 파일] package [패키지명] -v [버전]
    - 예제: dotnet add ./helloworld/helloworld.csproj package akka -v 1.3.16
  - N개
    - ~~TODO: 명령: dotnet add [프로젝트 파일] 1개 package [패키지명 조건] N개~~
- NuGet 패키지 참조 목록보기
  - 명령: dotnet list [프로젝트 파일] package   
  - 예제: dotnet list ./helloworld/helloworld.csproj package   
- NuGet 패키지 참조 제거하기
  - 1개
    - 명령: dotnet remove [프로젝트 파일] package [패키지명]
    - 예제: dotnet remove ./helloworld/helloworld.csproj package akka
  - N개
    - ~~TODO: 명령: dotnet remove [프로젝트 파일] 1개 package [패키지명 조건] N개~~
- ~~TODO: NuGet 패키지 업데이트 가능 유/무 확인하기~~
- ~~TODO: NuGet 패키지 업데이트하기~~
- ~~TODO: NuGet 패키지 복원하기~~
	
### 빌드
- 솔루션 빌드하기
  - 명령: dotnet build [솔루션명] -c [debug | release] -f [프레임워크명] -v [q[uiet] | m[inimal] | n[ormal] | d[etailed] | diag[nostic]]
  - 예제: dotnet build helloworld.sln -c release -f netstandard2.1
- ~~TODO: 솔루션 재빌드 ~~
- 솔루션 정리하기
  - 명령: dotnet clean -c [debug | release]
  - 예제: dotnet clean -c release
- 프로젝트 빌드하기	
  - 명령: dotnet build [프로젝트명] -c [debug | release] -f [프레임워크명]
  - 예제: dotnet build helloworld.proj -c release -f netstandard2.1
- 프로젝트 실행하기
  - 명령: dotnet run --project [프로젝트명] -c [debug | release] -- 프로그램인수
  - 예제: dotnet run --project ./helloworld/helloworld.csproj -c debug -- xyz 2019
- ~~TODO: 여러 프로젝트  빌드하기~~
- ~~TODO: 프로젝트 정리하기~~

### 단위 테스트
- 빌드하기
- 코드 커버리지 확인하기
- 단위 테스트 디버깅하기

### 요약
- dotnet new
  - dotnet new sln
  - dotnet new classlib
  - dotnet new xunit
- dotnet sln
  - dotnet sln add ... .csproj
  - dotnet sln remove ... .csproj
- dotnet build  
  - dotnet build ... -c Release -f netcoreapp2.2
- dotnet run
   - dotnet run --project ... -c Release -f netcoreapp2.2
- dotnet clearn  
  - dotnet clearn -c Release -f netcoreapp2.2
- dotnet add/remove/list
  - 프로젝트
    - dotnet add reference ... .csproj
    - dotnet remove reference ... .csproj
    - dotnet list reference
  - NuGet 패키지
    - dotnet add package ... .csproj
    - dotnet remove package ... .csproj
    - dotnet list package  

## Visual Studio Code

### 확장 도구
- C#, Microsoft
- vscode-icons, VSCode Icons Team
- .NET Core Test Explorer
- NuGet Package Manager, jmrog
- NuGet Package Manager, jmrog
- Markdown Preview Enhanced, Yiyi Wang
- Markdown All in One, Yu Zhang
- CSharp to PlantUML, PlantUML Syntax
- Markdown PDF

### 단축키
- 팔레트: Ctrl + Shift + P

### 디버깅
- launch.json 파일: 디버깅 정보 파일
  - https://elanderson.net/2018/04/run-multiple-projects-in-visual-studio-code/
  ```
  .vscode/launch.json
  {
    "configurations": [
      {
         "args": [], -(변경)-> "args": ["xyz", "abc"],
	     "program": "${workspaceFolder}/CalcApp/bin/Debug/netcoreapp2.2/CalcApp.dll",
      }  
    ]
  }
  ```

## TODO(Q&A)
- tasks.json 파일 이해하기
- lunch.josn 파일 이해하기
- using 구문 추가 IntelliSense?
- obj, bin 등 특정 폴더를 표시하지 않기.
- Workspace
- using 구문 인텔리센스?
- Dll or Exe?
- Code Coverage 확인?
- 복수개 프로젝트 동시 실행(순서 지정)?
- 복수개 프로젝트 개별 실행?
- 플랫폼 지정(Any CPU, ...)
- VSCode에 설치된 확장 도구 목록 확인하기
- launch/tasks.json 파일 이해하기, [링크](- https://docs.microsoft.com/ko-kr/visualstudio/ide/customize-build-and-debug-tasks-in-visual-studio?view=vs-2019)
- .code-workspace 확장자?
- Terminal
- 확대/축소
