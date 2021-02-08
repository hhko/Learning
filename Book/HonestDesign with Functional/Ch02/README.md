## 로그


### 1. 로그 수준
- 관심도: Fatal > Error > Warn > Info > Debug > Trace

<br/>

### 2. 로그 수준별 대상자
- 운영자: Fatal, Error, Warn, Info
- 개발자: Fatal, Error, Warn, Info, Debug, Trace

<br/>

### 3. 로그 수준 정의
- **Trace: 메서드 실행을 추적(시작과 종료)한다.**
   - 위치: 
     - 시작: 메서드 첫 줄
     - 종료: 메서드 끝 줄
   - 형식: 
     - 시작: [메서드 명] - Enter
     - 종료: [메서드 명] - Exit
   - 예
     ```cs
     public void DoSomethin(int x, int y)
     {
        -logger.Trace("DoSomething - Enter");    // 메서드 시작
        ...
        _logger.Trace("DoSomething - Exit");     // 메서드 끝
     }
     ```     

<br/>


- 작업 중
```
<!--
1. 로그 목표
1. 로그 형식
	1. 로그 코딩 표준화
		1. 환경 파일: Configurations\App.NLog.config
		  NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(@"Configurations\nlog.config");
		1. 로그 정리
		  Shutdown
		1. 로그 예외 발생처리 방법: 예외 vs. 콘솔
		  throwConfigException="true" vs. internalLogToConsole="true"
		1. NLog 로그
		  internalLogToConsole vs. internalLogToTrace vs. 파일?
		1. NLog 환경 설정 Runtime에 변경하기
		  autoReload="true"
		  https://github.com/nlog/nlog/wiki/Configuration-file#automatic-reconfiguration
		1. 시간?
		  https://github.com/NLog/NLog/wiki/Time-Source
		1. 환경 파일 자동 복사하기: Release와 Debug 모드를 구분하여 자동복사
		  App.패키지명.config
		  App.패키지명.debug.config
	1. 로그 수준별 위치: Trace(AOP)
	1. 로그 형식
		1. Debug(JsonLayout)
		  - {xyz} 차단 시키기: parseMessageTemplates="false"
		  https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
		  - @x includeAllProperties vs. excludeAllProperties
		  - filters
		1. Warn 이상: what, why, how
		1. Error: 예외 NLog 형식
	1. 로거
		1. 의존성: Autofac
	1. NLog Logger
		<logger name="xyz.*" minLevel="Trace">
			<logger writeTo="c"/>
			<logger writeTo="f"/>
		</logger>
1. 로그 단위 테스트
	1. 로그 수준: 카운트
1. 로그 전송
	1. Elasticsearch
	1. 비동기 및 실패 처리(DB, ...)
	
<target xsi:type="Console" name="c"
		layout="${longdate} ${logger} ${level} ${message}"/>
		
ILogger vs. Logger
- Logger는 WithProperty, ConditionalDebug, ... 등 부가적인 기능을 더 많이 제공한다.
  예.    _logger
			.WithProperty("속성명", 속성값)
			.Info("...");
-->
<!--
// NLog + Elasticsearch
https://damienbod.com/2016/08/20/asp-net-core-logging-with-nlog-and-elasticsearch/
https://github.com/markmcdowell/NLog.Targets.ElasticSearch

https://www.humankode.com/asp-net-core/logging-with-elasticsearch-kibana-asp-net-core-and-docker

// NLog
https://github.com/NLog/NLog/wiki/JsonLayout

// Exception 출력 형식
https://github.com/NLog/NLog/wiki/How-to-log-exceptions
https://github.com/NLog/NLog/wiki/Exception-Layout-Renderer
https://github.com/NLog/NLog/wiki/OnException-Layout-Renderer
https://nlog-project.org/2011/04/20/exception-logging-enhancements.html

// 예외가 발생될 때 형식을 지정한다.
${onexception:inner= ... } 

// NLog.config 파일 읽기
https://github.com/NLog/NLog/wiki/Explicit-NLog-configuration-loading
-->
```

```
- FIRST 원칙
  - Fast — 유닛 테스트는 빨라야 한다.
  - Isolated — 다른 테스트에 종속적인 테스트는 절대로 작성하지 않는다.
  - Repeatable — 테스트는 실행할 때마다 같은 결과를 만들어야 한다.
  - Self-validating — 테스트는 스스로 결과물이 옳은지 그른지 판단할 수 있어야 한다. 특정 상태를 수동으로 미리 만들어야 동작하는 테스트 등은 작성하지 않는다.
  - Timely — 유닛 테스트는 프로덕션 코드가 테스트를 성공하기 직전에 구성되어야 한다. 테스트 주도 개발(TDD) 방법론에 적합한 원칙이지만 실제로 적용되지 않는 경우도 있다.
  - 소스: https://medium.com/@ssowonny/%EC%84%A4%EB%A7%88-%EC%95%84%EC%A7%81%EB%8F%84-%ED%85%8C%EC%8A%A4%ED%8A%B8-%EC%BD%94%EB%93%9C%EB%A5%BC-%EC%9E%91%EC%84%B1-%EC%95%88-%ED%95%98%EC%8B%9C%EB%82%98%EC%9A%94-b54ec61ef91a

     
     - TODO: 여러 Logger을 사용할 것인가? 목표: 개별 형식을 갖을 수 있다(구분하기가 쉽다).
     - TODO: Debug 로그 예제가 필요하다. 값 변경 전 / 후
     - TODO: 다른 클래스에서 메서드 명이 같을 때?
       - LogManager.GetLogger("로거"); vs. LogManager.GetCurrentClassLogger(); ${logger} -> 네임스페이스.클래스
         - private static Logger logger = LogManager.GetCurrentClassLogger();
       - ${callsite} -> 네임스페이스.클래스.메서드
       - ${callsite:fileName=true} ${newline} -> 네임스페이스.클래스.메서드 <소스파일 전체 경로:라인번호>
     - 디버그 로그 적용 예
       ```cs
       _logger.Debug("{oldName} changed name to {newName}", _name, name);
       _name = name;
       _logger.Debug("nameof(_name) changed to {newName}" name);
       ```

- **Debug: 디버깅을 위한 값을 출력한다.**
   - 위치: 없음(값을 확인하기 위한 어떤 위치도 가능하다)
   - 형식: 없음(값을 출력하기 위한 어떤 형식도 가능하다) 
     - TODO: 구조적 NLog
   - 예
     ```cs
     public void DoSomethin(int x, int y)
     {
        _logger.Trace("DoSomething - Enter");    // 메서드 시작
          
        _logger
        if (...) 
        {
         
        }
          
        ...
        _logger.Trace("DoSomething - Exit");     // 메서드 끝
     }
     ```
 - Info: 메서드 성공 정보를 출력합니다.
   - "메서드 : Info 로그 = 1 : 1"은 단일 책임 원칙(Single Responsibility Principle)을 준수하도록 강요합니다.
 - Warn: 메서드 실행이 실패할 때(조기 반환할 때, ...) 그 이유를 출력한다.
 - Error: 메서드 실행 과정에서 예외를 출력한다.
 - Fatal: 시스템이 더 이상 정상적으로 동작할 수 없을 때 출력한다.
   - 메서드 실패
   - 메서드 예외 처리
   - //메서드 실행 과정에서 더 이상의 진행에 의미가 없을 때 그 이유를 출력한다.

로그 형식
- Impact To System: What is not going to work
- Reason for problem: Why is it not going to work
- Relevant Information: How to make it work


[Warn] Can't store customer Larry phone number(123456789) because it is 11 digits. (Database supports 10 digit phone numbers)
 - What: Can't store customer Larry phone number(123456789)
 - Why: because it is 11 digits.
 - How: (Database supports 10 digit phone numbers)
 
 형식: Can't  실패한 행위와 정보(값)를 기술한다 becase 실패 이유을 기술한다. (정상 처리 조건을 기술한다) 
 사례: Can't store device
 
 
 No information can be saved or displayed in the system 
 becase the system can not connect to the database
 Application will not function
 _sqlConnection = {@sqlConnection) \n
 _...
 ```

### 4. 로그 단위 테스트
- Tightly Coupled Dependencies
  - Test dependency
  - Test class
- Tightly Coupled NLog
  - Test NLog 쉽다.
  - Test class 쉽다.
  - LogManager.ThrowExceptions

### 5. FAQ
- Debug 수준으로 사용자 정의 메서드 호출 정보를 출력해도 될까요?
- 외부 메서드 호출 정보는 어떻게 출력해야 하나요?
- ...?
```
