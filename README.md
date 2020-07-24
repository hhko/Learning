# Learning is exciting for developers.
- 배움은 설렘이다 for developers.

## 함수형 주요 특징
### 1. 함수
1. Expression vs. Statement
   - Expression 
     - [An expression in a programming language is **a syntactic entity** that **may be evaluated** to determine its value.](https://en.wikipedia.org/wiki/Expression_(computer_science))
     - **결과 값이 있다.**
     - 예. if 구문에 결과 값이 있다(then과 else는 expression만 허용한다).
       ```
       // F# IF 구문 
       // if boolean-expression then expression1 [ else expression2 ]
       //
      
       let test x y =
         if x = y then "equals"
         elif x < y then "is less than"
         else "is greater than"
      
       printfn "%d %s %d." 10 (test 10 20) 20
       ```
   - Statement
     - [a statement **only containing executable code** and a definition instantiating an identifier, while an expression evaluates to a value only.](https://en.wikipedia.org/wiki/Statement_(computer_science))
     - **결과 값이 없다.**
     - 예. if 구문에 결과 값이 없다(명시적으로 return 구문을 추가해야한다).
       ```
       // C# IF 구문
       // if (boolean-expression)
       // {
       //     statement;
       // }
       // else
       // {
       //     statement;
       // }
       //
      
       string Test(int x, int y)
       {
           if (x == y) return "equals";
           else if (x < y) return "is less than";
           else return "is greater than";
       }
       
       WriteLine($"10 {Test(10, 20)} 20");
       ```
   - Expression과 Statement 관계
     - [A statement may have internal components (e.g., expressions).](https://en.wikipedia.org/wiki/Statement_(computer_science))  
     <img src="./Images/Expression_vs_Statement.png"/>
   - 왜 Expression이 중요한가?
     - 수학 함수 정의 : [첫 번째 집합의 임의의 한 원소를 두 번째 집합의 오직 한 원소에 대응시키는 이항관계다. ](https://ko.wikipedia.org/wiki/%ED%95%A8%EC%88%98)  
	   <img src="./Images/Wiki_Function.png"/>
	 - 수학 함수 f는 입력 x와 출력 y을 갖는다.
	 - Expression을 통해 프로그램 세계의 함수도 입력(argument type)과 출력(return type)을 갖는다(Statement은 출력이 선택적이다).
	 - Expression을 통해 프로그램 세계의 함수가 수학 함수 성질 중 "입력과 출력" 존재를 충족 시킨다.
1. Expression과 Declarative, Composition, Readable 관계
   ```
   Expression : Founction Name → Declarative ─────────────┐
      │                                                   ↘
     input/output : Function Signature → Pure → Predictable → Testable → Maintainable 
      ↓                                                   ↗
   Composition : Function Flow → Readable ────────────────┘  
   ```
1. Map vs. Bind vs. Return : Normal World vs Elevated World(Containerized)
   <img src="./Images/Map_vs_Bind_vs_Return.png"/>

### 2. 자료구조
1. 불변 vs. 가변

## 목차
1. 책
   - [함수형 프로그래밍 in C#](./Books/FPinCSharp)
     - [Chapter 02. Why function purity matters](./Books/FPinCSharp/Ch02)
     - [Chapter 03. Designing function signatures and types](./Books/FPinCSharp/Ch03)	
     - [Chapter 05. Designing programs with function composition](./Books/FPinCSharp/Ch05)	
   - [오브젝트](./Books/Object)
     - [Chapter 00. 패러다임](./Books/Object/Ch00)
     - [Chapter 01. 객체, 설계](./Books/Object/Ch01)
   - [C#으로 배우는 적응형 코드](./Books/AdaptiveCode)
     - [Chapter 07. Covariance & Contravariance](./Books/AdaptiveCode/Ch07)
   - [Designing with Types](./Books/DesigningWithTypes)
     - [Chapter 01. Introduction](./Books/DesigningWithTypes/Ch01)
   - [애자일 마스터](./Books/AgileSamurai)
     - [1장. 애자일의 핵심](./Books/AgileSamurai/Ch01.md)
     - [2장. 애자일 팀 만나기](./Books/AgileSamurai/Ch02.md)
     - [3장. 모두 한 버스에 타는 법](./Books/AgileSamurai/Ch03.md)
     - [4장. 크게 보기](./Books/AgileSamurai/Ch04.md)
1. 강의
   - [Advanced Defensive Programming Techniques](./Lectures/DefensiveProgramming)
1. 플랫폼
   - [Git](./Platform/Git)
   - [.NET Core](./Platform/NETCore)
1. 패키지
   - [NLog](./Packages/NLog)
     - [로그 정책](./Packages/NLog/Policy)
     - [로그 단위 테스트](./Packages/NLog/UnitTest)
     - [로그 출력 자동화](./Packages/NLog/Tracer)
1. 블로그
   - [Mark Seemann](./Blogs/MarkSeemann)
     - [Refactoring to Aggregate Services](./Blogs/MarkSeemann/RefactoringToAggregateServices)
   - [Others](./Blogs/Others)	
     - [How To Debug LINQ Queries in C#](./Blogs/Others/HowToDebugLINQQueriesInCSharp)
     - [How to Use and Unit Test ILogger](./Blogs/Others/HowToUseAndUnitTestILogger)
     - [ASP.NET Core 3.1 Web API Quick Start](https://medium.com/imaginelearning/asp-net-core-3-1-microservice-quick-start-c0c2f4d6c7fa)
1. Awesome
   - [함수형 프로그래밍](./Awesome/FP)
