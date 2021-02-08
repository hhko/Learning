# 설계 시작과 끝은 테스트다 for functional C# beginners.

## 환경 구성하기
1. VS Code C#
1. Code Coverage
1. GitHub 빌드 자동화
1. GitHub 배포

## 설계하기
1. 패러다임
   - WHAT(추상화 목표)
     - 객체지향: 변경을 수용한다.
     - 함수형: 부작용을 최소화한다.
   - HOW   
     - 객체지향: 객체와 관계(객체의 조합: 협력)
     - 함수형: 순수함수와 흐름(모나드와 합성 함수)
   - 정리 중
     - 객체 vs. 모나드
     - 관계(다형성 <- 상속) vs. 흐름(합성 함수 <- 순수 함수)
     - 클래스(데이터와 로직) vs. ...?
     - 추상화 방법(인스턴스) vs. 추상화 방법(...?)
1. 도메인 표현 시작하기
   - 함수명 없이 입출력 타입명만으로도 도메인을 표현할 수 있어야 한다.
   - Primitive Obsession
1. 순수 함수
   - 정의: 함수에 입력된 인수에만 의존하여 외부 상태 변경없이 함수의 출력값을 반환한다.
     - 입력된 인수 외에는 의존하지 않는다(참조 투명성, Referentially Opaque).
     - 결과값 이외에 다른 상태를 변경하지 않는다(부수 효과가 없다, Side-effect free).
   - 구분
     - statement vs. expression
   - 효과
     - 함수를 연결 시킬 수 있다(함수를 연속 호출할 수 있다).
       - 모든 함수는 출력 값을 갖고 있다.
     - 함수 시그니처만으로 함수 동작을 예측할 수 있다.
       - 함수 시그니처에 표현된 것만 수행한다.
       - 함수는 단일 책임 원칙을 준수하게 된다.
     - 동일한 입력을 주면, 항상 동일한 결과를 얻는다.
       - 시간에 의존하지 않는다.
       - 장소에 의존하지 않는다.
       - 실행 횟수에 의존하지 않는다.
     - 단위 테스트하기 쉽다.
       - 함수 의존성이 모두 인수로 표현되어 있다.
     - 동시에 실행할 수 있다.
   - 예제
     - 예외, 시간, 랜덤, 파일, ...
1. 의존성
   - IoC(DI)
   - Factory: 의존성 전파 차단하기
   - Singleton: 정적 클래스 or 정적 메서드
1. 타입
   - 공변성 vs. 반공변성
   - primitive
   - operator 연산자
1. 패턴
   - Default Factory: 생성자
   - Factory
   - Builder
   - Singleton(DI)
   - Strategy vs. Template Method
   - Visitor(Acyclic Visitor)
     - http://michaelparshin.blogspot.com/2013/06/acyclic-visitor-implementation-without.html?m=1
   - Fluent Interfae
1. C# 8.0
   - NULL
   - 패턴 매칭
   - 로컬 함수

## 테스트 패키지 익히기
1. 전역
   - 기본: xUnit
   - 성능: BenchmarkDotNet, NBench
1. Assert
   - 의존성: Autofix, Moq
   - 데이터: AutoFixture
1. Act
1. Assert
   - Fluent Assertions
   - ApprovalTests
1. 제외 대상
   - FsCheck
   - SpecFlow
   
## 불순 함수 테스트하기
1. Configuration File: .json
1. Log: NLog, SeriLog
1. File System: File.ReadAllText
1. Http: HttpClient
1. FTP: WebRequest
1. gRPC: ProtoBuf
   - https://docs.microsoft.com/ko-kr/aspnet/core/grpc/?view=aspnetcore-3.1
1. REST
1. DB: EF Core
1. Time: DateTime.Now

## 적용하기
1. (게임 예제)...
1. [Designing with types](https://fsharpforfunandprofit.com/series/designing-with-types.html)
1. blazor 예제

## 참고 자료
1. https://github.com/xunit/samples.xunit
1. https://github.com/xunit/xunit.analyzers
1. https://github.com/xunit/testextensions.xunit

## 참고 도서
1. [Functional Programming in C# 스터디 자료](https://github.com/hhko/Books/tree/master/Design/FPinCSharp)
