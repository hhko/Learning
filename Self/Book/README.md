## 단위 테스트 패키지
- 단위 테스트 기본 패키지 
  - 단위 테스트
    - xUnit
	- xUnit.Runner.VisualStuio, - xUnit.Runner.Console
  - Arrange
    - AutoFixture
	- Moq : DI(IoC) Container
  - Assert
    - Fluent Assertion
	- ?
- 코드 커러비지 패키지
  - Microsoft 
	- Microsoft...Sdk
  - 코드 커버리지
    - Coverlet
	- ...
- 단위 테스트 방법론
  - 성능 단위 테스트
    - BenchmarkDotNet
	- NBench
  - 속성 기반 단위 테스트
	- FsCheck
	- Expecto
  - BDD
- 부작용 단위 테스트 패키지
  - FileSystem : System.IO.Abstractions
  - HttpClient : Microsoft.Extensions.Http
  - ASP.NET Core : 
  - EF.Core : 
- 화면 단위 테스트
  - Web
  - Desktop
  
## 설계 원칙
- 단위 테스트틑 알고 있는 경우의 수를 테스트하는 것이다.
- 의존성 식별
  - `new`키워드는 후보
  - 불순(Impure) 메서드
  - Primitive Types and Strings -> the strongly-typed option pattern
    - POCO?
- 의존성 -> 의존성 주입 컨테이너
  - 주입 방법 : 생성자 주입, ...

  
## 스토리  
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
- 의존성 식별 방법
  - `new` 키워드는 후보 대상이다.
  - 의존성
    - 부작용
	- HOW 변화
  - 의존성이 아닌 것.  
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