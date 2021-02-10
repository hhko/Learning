1. General
   - Create logger
   - Write to Console
   - Static logger
   - Write to file
   - Output template
1. Limit
   - File size limit bytes
   - Rolling interval
   - Retained file count limit
1. Structural
   - Sclar
   - Collection and object
   - Destructure operator
   - Destructure by transforming
   - Json
   - SQLite
1. MinimumLevel
   - Global minimum level
   - Specific minimum level
1. Context
   - **Source context**
   - **Minimum level source context**
   - **Context keyvalue**
1. Filter
   - **By excluding with matching filter**
   - **By excluding with properties filter**
   - By including only
1. Enrich
   - With property
   - Custom Property
1. Self Debugging
   - Self log
1. Configuration
   - Json configuration
   - Xml configuration
----
1. Dynamci log level
1. Sub logger (조건)
1. AudioTo?
1. Timed
1. Destructure 깊이
1. Destructure 너비
1. .NET 최소 버전
1. Sinks.Async NuGet
1. Sinks.Http NuGet
1. Sinks.Loki
1. Sinks.ElasticCommonSch...
1. Custom Sink
1. Configuration GitHub 예제 따라하기
1. json 콘솔 읽기(Tail)
1. Json 뷰어(UI)
1. 단위 테스트
1. 의존성 주입
1. Encoding
1. 시간 UTC -> KST
1. 반복 코드 Template Akka
1. 반복 코드 Template App, ...
1. 형식 Timestamp:...
1. 표준화 {???(공통 구조 키워드)}
1. 코드 자동화(Fody?)
1. **Kafka 토픽 정보 Key/Value**
1. **대시보드 : Discover**
1. **대시보드 : Job**
1. **검증 : 대량, 대용량, 전송실패(재시도), 장시간, 데이터손실 처리?**

- https://www.devground.co/blog/posts/serilog-sending-logs-to-logstash/
- https://medium.com/@letienthanh0212/building-logging-system-in-microservice-architecture-with-elk-stack-and-serilog-net-core-part-2-2643dbbf3c2c
- https://dev.to/hasdrubal/structure-logging-with-serilog-and-seq-and-elasticsearch-under-docker-16dk
- https://oksala.net/2020/01/24/configure-serilog-with-logstash-and-elasticsearch/
- https://github.com/tsimbalar/serilog-settings-comparison/blob/master/docs/README.md
- https://m.youtube.com/watch?v=f3pposukOSE&feature=youtu.be

```
https://github.com/datalust/clef-tool/releases
	https://github.com/serilog/serilog-expressions
	- [x] clef -i log-20170509.clef
	- [ ] clef -i log-20170509.clef --filter="Version > 100"
	- [x] clef -i log-20170509.clef --format-json
	- [x] clef -i log-20170509.clef --format-template="[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] {Message}{NewLine}"
	- [x] clef -i log-20170509.clef -o log-20170509.txt
https://github.com/warrenbuckley/Compact-Log-Format-Viewer/releases



현재 우리는?
1. 텍스트 형식만 있는 로그 내용(정규식 등을 이용한 검색) -> 구조화
1. 여러 로그 파일										 -> 통합
1. 운영 데이터베이스에 로그 저장						 -> 전용 저장소
1. Fault Investigation/Resolution

저장소
	Elasticsearch
	RavenDB
	Loki?
	influxdb
	SQLite : https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox

로그 타입
	ILogger
	Log.Logger		// 싱글톤

로거 만들기
new LoggerConfiguration()
                .CreateLogger();

출력
	콘솔 .WriteTo.Console()
	파일 .WriteTo.File("./Logs/LogFile.txt")
	Http
	
출력 템플릿 내재화
	outputTemplate
	
출력 제한 조건
	파일 크기 fileSizeLimitBytes : (1GB)
	파일 생성 rollingInterval : (Infinite), Year, Month, Day, Hour, Minute
	파일 개수 retainedFileCountLimit : (31)
	
환경 설정
	코드
	파일
		Serilog.Settings.Configuration 
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
			.ReadFrom.Configuration(configuration)

		Serilog.Settings.AppSettings 
			.ReadFrom.AppSettings() 
			App.config

데이터 타입
	Scalar 데이터 타입 : nullable?
	Collection/Object 
		IEnumerable
		Dictionary<Scalar 타입, ?>
		ToString()
	
	destructuring operator

수준
수준 필터

형식
	{Named Property} <- Property Value : RenderedMessage : .... 구조.구조.Xyz:"값"




버전
	.NET Framework
	.NET Core
	.NET 					5

	
단위 테스트


로그 Level 가이드

코드 템플릿
	프로그램 기본 코드(환경 설정 포함)
	Actor 반복
	클래스 반복
	Fody or Source Generator



- [x] Serilog, 2.10.0
- [x] Serilog.Sinks.Console, 3.1.1
- [x] Serilog.Sinks.File, 4.1.0
- [x] Serilog.Settings.Configuration, 3.1.0
- [x] Serilog.Settings.AppSettings, 2.2.2
- [x] Serilog.Formatting.Compact, 1.1.0			--> CKEF(Compact Log Event Format Tool)

  |                      Formatter |    Median  |    StdDev | Scaled |
  |:------------------------------ |----------: |---------: |------: |
  |                `JsonFormatter` | 11.2775 &micro;s | 0.0682 &micro;s |   1.00 |
  |         `CompactJsonFormatter` |  6.0315 &micro;s | 0.0429 &micro;s |   0.53 |
  |        `JsonFormatter(renderMessage: true)` | 13.7585 &micro;s | 0.1194 &micro;s |   1.22 |
  | `RenderedCompactJsonFormatter` |  7.0680 &micro;s | 0.0605 &micro;s |   0.63 |
  
  | Property | Name | Description | Required? |
  | -------- | ---- | ----------- | --------- |
  | `@t`     | Timestamp | An ISO 8601 timestamp | Yes |
  | `@m`     | Message | A fully-rendered message describing the event | |
  | `@mt` | Message Template | Alternative to Message; specifies a [message template](http://messagetemplates.org) over the event's properties that provides for rendering into a textual description of the event | |
  | `@l` | Level | An implementation-specific level identifier (string or number) | Absence implies "informational"  |
  | `@x` | Exception | A language-dependent error representation potentially including backtrace | |
  | `@i` | Event id | An implementation specific event id (string or number) | |
  | `@r` | Renderings | If `@mt` includes tokens with programming-language-specific formatting, an array of pre-rendered values for each such token | May be omitted; if present, the count of renderings must match the count of formatted tokens exactly |

- [ ] Serilog.Sinks.SQLite, 5.0.0
- [ ] Serilog.Expressions


Visual Studio 도구 
- https://github.com/Suchiman/SerilogAnalyzer

사용자 정의 출력(Sinks)  

사용자 정의 데이터(Enrichers)

시간 UTC -> KST

성능 Async Logging

- [ ] 구조적 로그 | Kafka 토픽 항목 추가
- [ ] Sink | Serilog.Sinks.Console 매뉴얼 확인
- [ ] Sink | Serilog.Sinks.File 매뉴얼 확인
- [ ] Sink | Serilog.Sinks.File 로그 파일명 동적 지정?
- [ ] Sink | Serilog.Sinks.File Rolling 로그 파일명 동적 지정?
- [ ] Sink | Serilog.Sinks.SQLite 내용 확인 불가?
- [ ] Tool | SerilogAnalyzer 세부 내용 확인
- [x] 출력 매개변수 | string path,
- [x] 출력 매개변수 | string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
- [x] 출력 매개변수 | RollingInterval rollingInterval = RollingInterval.Infinite,
- [x] 출력 매개변수 | int? retainedFileCountLimit = 31,
- [x] 출력 매개변수 | ITextFormatter formatter, // JsonFormatter
- [ ] 출력 매개변수 | LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
- [ ] 출력 매개변수 | IFormatProvider formatProvider = null,
- [ ] 출력 매개변수 | long? fileSizeLimitBytes = 1073741824,
- [ ] 출력 매개변수 | LoggingLevelSwitch levelSwitch = null,
- [ ] 출력 매개변수 | bool buffered = false,
- [ ] 출력 매개변수 | bool shared = false,
- [ ] 출력 매개변수 | TimeSpan? flushToDiskInterval = null,
- [ ] 출력 매개변수 | bool rollOnFileSizeLimit = false,
- [ ] 출력 매개변수 | Encoding encoding = null,
- [ ] 출력 매개변수 | FileLifecycleHooks hooks = null);
- [x] LoggerConfiguration | Destructure | ByTransforming
- [ ] LoggerConfiguration | Destructure | ByTransforming<T>
- [ ] LoggerConfiguration | Destructure | ByTransformingWhere<T>
- [ ] LoggerConfiguration | Destructure | ToMaximumCollectionCount
- [ ] LoggerConfiguration | Destructure | ToMaximumDepth
- [ ] LoggerConfiguration | Destructure | ToMaximumStringLength
- [ ] LoggerConfiguration | Destructure | With
- [ ] LoggerConfiguration | Destructure | With<T>
- [ ] LoggerConfiguration | Destructure | 형식(:l, :0.00, ...)
- [ ] LoggerConfiguration | MinimumLevel | 전역 최소 수준
- [ ] LoggerConfiguration | MinimumLevel | 특정 최소 수준
- [ ] LoggerConfiguration | MinimumLevel |Is?
- [ ] LoggerConfiguration | MinimumLevel |Override?
- [ ] LoggerConfiguration | MinimumLevel |ControlledBy 동적 변경
- [x] LoggerConfiguration | Filter | ByExcluding
- [x] LoggerConfiguration | Filter | ByIncludingOnly
- [ ] LoggerConfiguration | Filter | With
- [ ] LoggerConfiguration | Filter | With<T>
- [x] LoggerConfiguration | Filter | Matching | FromSource<T>   : ForContext
- [x] LoggerConfiguration | Filter | Matching | FromSource		: ForContext
- [x] LoggerConfiguration | Filter | Matching | WithProperty	: 키
- [x] LoggerConfiguration | Filter | Matching | WithProperty	: 키, 값
- [ ] LoggerConfiguration | Filter | Matching | WithProperty<T>
- [x] LoggerConfiguration | Enrich | WithProperty
- [ ] LoggerConfiguration | Enrich | Wrap
- [ ] LoggerConfiguration | Enrich | AtLevel
- [ ] LoggerConfiguration | Enrich | FromLogContext
- [ ] LoggerConfiguration | Enrich | When
- [ ] LoggerConfiguration | Enrich | With
- [ ] LoggerConfiguration | Enrich | With<T>

---
- [x] WriteTo
- [x] Destructure
- [x] MinimumLevel
- [x] ReadFrom
- [x] Filter
- [x] Enrich
- [ ] AuditTo


최소 수준 : 전역
최소 수준 : 출력 단위

출력 구분

의존성 주입(단위 테스트)


- [ ] Modern Structured Logging With Serilog and Seq
- [ ] Implementing Cross-cutting Concerns for ASP.NET Core Microservices
- [ ] Effective Logging in ASP.NET Core
- [ ] .NET Logging Done Right: An Opinionated Approach Using Serilog
- [ ] Serilog Enrichers: Getting Common Information into Log Entries
- [ ] Routing Serilog Log Entries with Filters and Formatters
- [ ] Securely Handling Errors and Logging Security Events in ASP.NET and ASP.NET Core

- [ ] Logging into Elasticsearch using Serilog and viewing logs in Kibana | .NET Core Tutorial
- [ ] Keep Calm And Serilog Elasticsearch Kibana on .NET Core - 132. Spotkanie WG.NET
- [ ] Centralized (and structured) logging with Serilog + Elastic
- [ ] Structured Logging with AspNet Core using Serilog and Seq
- [ ] Logging, Metrics and Events in ASP NET Core
- [ ] Elasticsearch for Dot Net Developers
- [ ] Start using simple logging mechanism in C# using a powerful Serilog framework.
- [ ] Application Diagnostics in .NET Core 3.1
- [ ] Microservices Logging
- [ ] C# Logging with Serilog and Seq - Structured Logging Made Easy
- [ ] Serilog: Instrumentation that Works for You
- [ ] Diving into Elasticsearch with .NET
- [ ] Getting started with Elasticsearch and .NET
- [ ] Elasticsearch Suggesters

- [ ] Serilog.Formatting.Compact.Reader
- [ ] Analogy.LogViewer.Serilog Json

- [ ] Serilog.Sinks.Http -> Logstash
- [ ] Elastic.CommonSchema.Serilog

NLog

Discover
Dashboard

Serilog Wiki

- http://blog.romanpavlov.me/logging-serilog-elk/
```

<br/>
<br/>

# learning-serilog
Serilog 배움 그리고 설렘

- [x] Formatter 이해하기(Json, Ealsticsearch) : [Writing logs to Elasticsearch with Fluentd using Serilog in ASP.NET Core](https://andrewlock.net/writing-logs-to-elasticsearch-with-fluentd-using-serilog-in-asp-net-core/)
  - CompactJsonFormatter
  - ElasticsearchJsonFormatter
- [ ]   
  - logstash 플러그인 : `RUN logstash-plugin install logstash-input-http`
  - logst
- [ ] 로그 Level 단위로 출력 파일 분리하기 : [Serilog and ASP.NET Core: Split Log Data Using Serilog FilterExpression](https://vmsdurano.com/serilog-and-asp-net-core-split-log-data-using-filterexpression/)

## 목차
1. **[데이터](#1-데이터)**
1. **[기능](#2-기능)**
1. **[단위 테스트](#3-단위-테스트)**
1. **[패키지](#4-패키지)**
1. **[참고 사이트](#5-참고-사이트)**

<br/>

## 1. 데이터
### 형식
- [x] Json : Serilog
- [ ] Json : NLog

### Encode
- [x] UTF-8 : 기본
- [ ] UTF-8 그 외

### 전송
- [x] Console : Serilog.Sinks.Console
- [x] File : Serilog.Sinks.File
- [x] HTTP : Serilog.Sinks.Http
- [ ] TCP

### 시간
- [x] UTC `@timestamp`
- [x] KST `events[0]:@timestamp`
- [ ] 사용자 정의
- [ ] 기본 시간 변경

### Host
- [x] IP : host
- [x] MachineName : `events[0]:host:name`, **WithMachineName**
- [x] UserName : `events[0]:_metadata:user_name`, **WithUserName**

### 프로세스
- [x] Process Name : `events[0]:process:name` (WithProcessName)
- [x] Process Id : `events[0]:process:pid` (WithProcessId)
- [x] Thread Name : (WithProcessName, WithProperty(ThreadNameEnricher.ThreadNamePropertyName, ...))
- [x] Thread Id : `events[0]:process:thread:id` (WithProcessId)
- [x] Log Level : `events[0]:log.evel`
- [x] Log Message : `events[0]:message`, `_metadata:...` [+소문자+]
  ```json
  "_metadata" => {
     "person" => {
        "age" => "2020",
        "$type" => "Person"
     }
  }
  ```
- [x] Exception : `events[0]:error:...` (WithExceptionDetails)

### 필드
- [x] 전역 변수 | 시스템 환경 변수 : `events[0]:_metadata:xxx`, **WithEnvironment**
- [x] 전역 변수 | 사용자 변수 : `events[0]:_metadata:xxx`, **WithProperty**
- [x] 전역 변수 | 함수 : `events[0]:_metadata:xxx`, **WithFunction**
- [x] 전역 변수 | LogEvent 사용자 함수 : `events[0]:_metadata:xxx`, **WithFunction**
- [x] 전역 변수 | 직접 구현 : [Creating custom serilog enrichers](https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/)
- [x] 영역 변수 | 구분 : `events[0]:_metadata:구분키`, **Enrich.FromLogContext(), using (LogContext.PushProperty("구분키", 구분값))**
- [x] 영역 변수 | 성능(시간) : `events[0]:_metadata:outcome`, **using (Operation.Time("Submitting payment for {OrderId}", "1234"))**
- [ ] 영역 변수 | 공통

<br/>

## 2. 기능
### 서비스
- [x] 로그 Elasticsearch 출력 형식 : **new EcsTextFormatter**
- [ ] **[+진행 : 로그 콘솔/파일 출력 형식+]**
- [ ] **[+진행 : 필드 추가+]**
- [ ] 환경 설정 읽기
- [ ] 환경 설정 다시 읽기
- [ ] 로그 수준 활성화
- [ ] 로그 수준 per Sinks 활성화 
- [ ] 로그 수준 동적 활성화 : https://nblumhardt.com/2017/10/logging-filter-switch/
- [ ] 전송 실패 확인?
- [ ] 동적 로그 파일 이름
- [ ] 로그 파일 출력 형식 : 콘솔, 파일
- [ ] 로그 파일 구분
- [ ] 로그 파일 전송 구분 : 로그, 작업, 연산 결과

### Collectbeat
- [x] Pipeline 구분 : beats, serilogs  
  - pipelines.yml : `7700-listen-beats`, `7701-listen-serilogs`
    ```yml
    - pipeline.id: 7700-listen-beats
      pipeline.workers: 4
      queue.type: persisted
      queue.max_bytes: 1gb
      path.config: "/usr/share/logstash/pipeline/7700-listen-beats.conf"
    - pipeline.id: 7701-listen-serilogs
      pipeline.workers: 4
      queue.type: persisted
      queue.max_bytes: 1gb
      path.config: "/usr/share/logstash/pipeline/7701-listen-serilogs.conf"
    - pipeline.id: alive
      pipeline.workers: 1
      path.config: "/usr/share/logstash/pipeline/alive.conf"
    ```
  - 7701-listen-serilogs.conf
- [x] Pipeline 실행 확인  
  ![image](/uploads/d034750b05ae050cf788ba49841a89f6/image.png)
- [ ] **[+진행 : Kafka 토픽 구분+]** : `serilog.{솔루션명}.{버전}`
  - serilog.daq.45

### Kafka
### Logstash-consumer

### Elasticsearch
### Kibana

<br/>

## 3. 단위 테스트
- [Elastic.CommonSchema.Serilog.Tests](https://github.com/elastic/ecs-dotnet/tree/master/tests/Elastic.CommonSchema.Serilog.Tests)
- [Elasticsearch.Extensions.Logging.IntegrationTests](https://github.com/elastic/ecs-dotnet/tree/master/tests/Elasticsearch.Extensions.Logging.IntegrationTests)

<br/>

## 4. 패키지
- [x] Serilog
- [x] Serilog.Enrichers.Context
- [x] Serilog.Sinks.Console
- [x] Serilog.Sinks.File
- [ ] Serilog.Sinks.Http
  - [x] Http
  - [ ] DurableHttpUsingTimeRolledBuffers
  - [ ] DurableHttpUsingFileSizeRolledBuffers
  - [ ] ExponentialBackoffConnectionSchedule
- [x] Elastic.CommonSchema.Serilog : Serilog.Enrichers.Process, Serilog.Enrichers.Thread, Serilog.Exceptions
- [x] SerilogTimings : SerilogMetrics
- [ ] ~~Elastic.Apm.SerilogEnricher~~ : 출력 안됨
- [ ] ~~Serilog.Enrichers.CorrelationId~~ : 출력 안됨
- [ ] ~~Serilog.Enrichers.Span~~ : 출력 안됨(.NET 5.0 이상)
- [ ] ~~Serilog.Exceptions~~
- [ ] ~~SerilogMetrics~~
---
- [ ] Serilog.Sinks.Async
- [ ] Serilog.Sinks.PeriodicBatching
- [ ] Serilog.Sinks.XUnit
- [ ] Serilog.Sinks.TestCorrelator
- [ ] Elastic.Elasticsearch.Xunit

<br/>

## 5. 참고 사이트
- [Andrew Lock | .NET Escapades](https://andrewlock.net/)
---
- [Nicholas Blumhardt](https://nblumhardt.com/)
---
- [x] [Creating custom serilog enrichers](https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/)
  - LoggerEnrichmentConfiguration 확장 메서드
  - ILogEventEnricher 인터페이스 구현
