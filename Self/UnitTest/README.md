# 단위 테스트

## 목표
1. 기초
   - 개요
   - [시작하기](./Part01_Fundamentals/Ch02_GettingStarted)
   
<br/>

## 패키지
1. 단위 테스트
   - 성공/실패 
     - xUnit, xUnit.Runner.Console/Wpf
   - Arrange
     - AutoFixture
     - Moq
     - Autofac, .NET Core, 팩토리 패턴
   - Assert
     - FluentAssertions
     - Approval Tests
1. 성능 단위 테스트
   - 측정 
     - BenchmarkDotNet
   - 성공/실패
     - NBench
1. 불순 함수
   - 파일 시스템
     - System.IO.Abstractions
   - 데이터베이스
     - EF Core, EfCore.TestSupport
     - Elasticsearch?
   - 로그
     - Serilog.Sinks.TestCorrelator, Serilog. ...
     - NLog. ...
   - HTTP
     - Http.Extension
   - Validation
     - Fluent Validation
   - Console
     - TestConsole
     - ConsoleLineApi
     - ...?
   - FTP
     - ...?
   - 통신(gRPC, ...)
     - ...?
   - 정적 클래스
     - 직접(인터페이스)
   - 확장 메서드
     - 직접?
   - 프로세스
     - CliWrap + 직접(인터페이스)
   - 레지스트리
     - 직접(인터페이스)
   - 시스템 환경 변수
     - 직접(인터페이스)
1. 통합 테스트
   - 웹
     - bUnit
     - Selenium
   - Desktop
     - Appium
   - 서비스
     - ...?
1. 단위 테스트 방법론
   - Property-based Test
     - FsCheck
   - BDD
     - SpecFlow
     - BDDfy
   - Fluent
     - xBeHave.xUnit
   - 기타
     - Expecto
1. CI/CD
   - 버전
     - GitVersionTask
   - 빌드
     - Cake
   - 코드 커버러지
     - Coverlet
     - ReportGenerator
   - 시스템
     - GitLab
     - GitHub
   - 코드 복잡도
   - 코드 품질 분석
   - 코드 의존성
   
<br/>

## 참고 사이트
- [ ] [Unit Tests, How to Write Testable Code and Why it Matters](https://www.toptal.com/qa/how-to-write-testable-code-and-why-it-matters) : Now 기반으로 단위 테스트 방법론 설명
