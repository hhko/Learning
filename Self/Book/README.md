## WHY. 단위 테스트
1. 명확해 진다.
   - 입/출력 중심 설계를 강요한다. : 사전 설계
   - 설계 준수를 강요한다. : 아키텍터 준수
   - 경우의 수를 누적 시킨다. : 기억 
   - 개발자 매뉴얼이다. : 실행가능한 문서

## 단위 테스트 패키지
1. 단위 테스트 기본 패키지 
   - 단위 테스트
     - xUnit
 	 - xUnit.Runner.VisualStuio, xUnit.Runner.Console
   - Arrange
     - AutoFixture
 	 - Moq
     - 의존성 컨테이너 : Microsoft.Extensions.DependencyInjection, Autofac
   - Assert
     - Fluent Assertion
 	 - Approval Tests 
1. 코드 커러비지 패키지
   - Microsoft 
 	 - Microsoft...Sdk
   - 코드 커버리지
     - Coverlet
 	 - HTML
1. 부작용 단위 테스트 패키지
   - Console : CommandLineApi
   - 환경 설정 : IOption<T>
   - 로그 : SeriLog
   - FileSystem : System.IO.Abstractions
   - HttpClient : Microsoft.Extensions.Http
   - ASP.NET Core : 
   - Blazor :
   - EF.Core : 
1. 화면 단위 테스트
   - Web
     - Selenium   
   - Desktop
1. 단위 테스트 방법론
   - 성능 단위 테스트
     - BenchmarkDotNet
	 - NBench
   - 속성 기반 단위 테스트
	 - FsCheck
	 - Expecto
   - BDD
     - Specflow
   - DB 
     - Scientist.NET
   - API 버전 관리
     - ApiApprovals
## 설계 원칙
1. 단위 테스트 정의 : 단위 테스트는 알고 있는 경우의 수를 메모리에서 테스트한다.
   - 알고 있는 경우의 수 : WHAT, 입/출력 정의
   - 메모리 : HOW
   - WHAT + HOW => any WHEN, any WHERE, any WHO 테스트할 수 있다. 예. CI/CD
1. 의존성 식별한다.
   - `new`키워드는 후보
   - 불순(Impure) 메서드
   - 정적 메서드
   - 싱글톤
1. 의존성 관리
1. 주 흐름을 식별한다.
   - 주 흐름 : Pipe 라인(마지막 인자, Curry)
   - 보조 흐름 : 사전 연결
1. Primitive obsession 

  
## 예제
1. 경우의 수 테스트 제약
   - 알고 있는 경우의 수를 테스트하는 것이다.
   - 알고 있는 경우의 수를 테스트할 수 없는 사례를 확인한다.
   - 점심시간 확인하기
     ```cs
	 bool IsLunchTime(DateTime time)
	 {
	 	return time.now... 12시 ~ 13시 사이면 true
	 }
	 
	 [Fact]
	 public 점심시간일_때()
	 {
	 	...
	 }
	 
	 [Fact]
	 public 점심시간이_아닐때()	// ...
	 {
	 	...
	 }
	 ```
1. 불순 함수(의존성) 식별 방법
1. DI 장점
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
