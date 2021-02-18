# Serilog Tutorial

## TODO
- [ ] 기본값 확인
  - ToMaximumCollectionCount
  - ToMaximumStringLength
  - ToMaximumDepth
- [ ] ControlledBy 코드
- [ ] With Property : Thread, ...  
---
- [ ] Sub Logger
- [ ] Sub Logger Dynamic.
---
- [ ] MVP
  - Logstash 전송 : Http
  - Fixed 필드, Kafka
  - Logstash pipeline
  - Elasticsearch/Kibana 확인
---  
- [ ] Raw 기본 출력 형식
- [ ] Visual Studio Serilog 확장 도구 https://github.com/Suchiman/SerilogAnalyzer
- [ ] NET 최소 버전
- [ ] { } 표준화?
- [ ] { :? } 형식
- [ ] 로컬 로그 뷰어 CLI
- [ ] 로컬 로그 뷰어 GUI
- [ ] 단위 테스트
- [ ] FromLogContext?
- [ ] AuditTo?
- [ ] 수행 시간 Timed, https://github.com/nblumhardt/serilog-timings
- [ ] 기본 정보 : 프로그램명, 프로그그램 버전, 로거명, 로거버전
- [ ] NuGET
  - Http
  - Async
  - ElasticCommonSchma
- [ ] 사용자 정의 필드, Kafka
- [ ] 사용자 정의
  - Fomrat 사용자 정의 만들기
  - Sink 사용자 정의 만들기
  - Enrich 사용자 정의 만들기
- [ ] 공통 코드 Akka
- [ ] 공통 코드 .NET Core
- [ ] 공통 코드 .NET Framework
- [ ] 공통 코드 조직화 : Log -> Validation -> Unit of Work -> Handle https://github.com/kgrzybek/modular-monolith-with-ddd
- [ ] Enrich 기능 기능
- [ ] Loki
- [ ] Serilog Wiki 읽기 https://github.com/serilog/serilog/wiki
- [ ] Encoding
- [ ] 시간 UTC -> KST
- [ ] 의존성 주입
- [ ] 대시보드 : Discover
- [ ] 대시보드 : Job
- [ ] 검증 : 대량, 대용량, 전송실패(재시도), 장시간, 데이터손실 처리?
- [ ] 전송 실패 확인?
- [ ] 동적 로그 파일 이름
- [ ] 데이터 타입
  - Scalar 데이터 타입 : nullable?
  - Collection/Object 
  - IEnumerable
  - Dictionary<Scalar 타입, ?>
  - ToString()
  - destructuring operator
- [ ] 로그 Level 가이드
- [ ] Docker?

<br/>

## 기능 요약
1. WriteTo
   - [x] string path,
   - [x] string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
   - [x] RollingInterval rollingInterval = RollingInterval.Infinite,
   - [x] int? retainedFileCountLimit = 31,
   - [x] ITextFormatter formatter, // JsonFormatter
   - [ ] LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose,
   - [ ] IFormatProvider formatProvider = null,
   - [ ] long? fileSizeLimitBytes = 1073741824,
   - [ ] LoggingLevelSwitch levelSwitch = null,
   - [ ] bool buffered = false,
   - [ ] bool shared = false,
   - [ ] TimeSpan? flushToDiskInterval = null,
   - [ ] bool rollOnFileSizeLimit = false,
   - [ ] Encoding encoding = null,
   - [ ] FileLifecycleHooks hooks = null);
1. Destructure
   - [x] ByTransforming
   - [ ] ByTransforming<T>
   - [ ] ByTransformingWhere<T>
   - [ ] ToMaximumCollectionCount
   - [ ] ToMaximumDepth
   - [ ] ToMaximumStringLength
   - [ ] With
   - [ ] With<T>
   - [ ] 형식(:l, :0.00, ...)
1. MinimumLevel
   - [ ] 전역 최소 수준
   - [ ] 특정 최소 수준
   - [ ] Is?
   - [ ] Override?
   - [ ] ControlledBy 동적 변경
1. Filter
   - [x] ByExcluding
   - [x] ByIncludingOnly
   - [ ] With
   - [ ] With<T>
   - [x] Matching | FromSource<T>   : ForContext
   - [x] Matching | FromSource		: ForContext
   - [x] Matching | WithProperty	: 키
   - [x] Matching | WithProperty	: 키, 값
   - [ ] Matching | WithProperty<T>
1. Enrich
   - [x] WithProperty
   - [ ] Wrap
   - [ ] AtLevel
   - [ ] FromLogContext
   - [ ] When
   - [ ] With
   - [ ] With<T>
1. AuditTo

<br/>

## 데이터
### 시간
- [x] UTC `@timestamp`
- [x] KST `events[0]:@timestamp`

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
- [x] 시스템 환경 변수 : `events[0]:_metadata:xxx`, **WithEnvironment**
- [x] 사용자 변수 : `events[0]:_metadata:xxx`, **WithProperty**
- [x] 함수 : `events[0]:_metadata:xxx`, **WithFunction**
- [x] LogEvent 사용자 함수 : `events[0]:_metadata:xxx`, **WithFunction**
- [x] 직접 구현 : [Creating custom serilog enrichers](https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/)
- [x] 구분 : `events[0]:_metadata:구분키`, **Enrich.FromLogContext(), using (LogContext.PushProperty("구분키", 구분값))**
- [x] 성능(시간) : `events[0]:_metadata:outcome`, **using (Operation.Time("Submitting payment for {OrderId}", "1234"))**

<br/>

## 패키지
- [x] Serilog, 2.10.0
- [x] Serilog.Sinks.Console, 3.1.1
- [x] Serilog.Sinks.File, 4.1.0
- [x] Serilog.Settings.Configuration, 3.1.0
- [x] Serilog.Settings.AppSettings, 2.2.2
- [x] Serilog.Formatting.Compact, 1.1.0			--> CKEF(Compact Log Event Format Tool)
- [x] Serilog.Enrichers.Context
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
- [ ] Serilog.Sinks.Async
- [ ] Serilog.Sinks.PeriodicBatching
- [ ] Serilog.Sinks.XUnit
- [ ] Serilog.Sinks.TestCorrelator
- [ ] Elastic.Elasticsearch.Xunit
- [ ] Serilog.Sinks.SQLite, 5.0.0
- [ ] Serilog.Expressions
- [ ] serilog-sinks-file-header
- [ ] serilog-sinks-file-gzip
- [ ] serilog-sinks-file-archive
- [ ] Serilog.Formatting.Compact.Reader
- [ ] Analogy.LogViewer.Serilog Json
- [ ] Elastic.CommonSchema.Serilog
- [ ] Serilog.Extensions.Hosting
- [ ] Serilog.Enrichers.Environment
- [ ] Serilog.Enrichers.Thread
- [ ] Serilog.Enrichers.Process
- [ ] Serilog.Enrichers.AssemblyName
- [ ] serilog-enrichers-memory
- [ ] Serilog.Filters.Expressions
- [ ] serilog-extensions-logging
- [ ] Serilog.Sinks.Debug
- [ ] Serilog.Sinks.RollingFile
- [ ] Serilog.Sinks.Elasticsearch
- [ ] Serilog.Formatting.Elasticsearch
- [ ] Serilog.Exceptions
- [ ] Serilog.Sinks.Map
- [ ] Destructurama.Attributed




<br/>

## 동영상
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

<br/>

## 블러그
- [x] How to destruct objects and log | [](https://ranjeet.dev/getting-started-with-serilog/)
- Sub Logger | [Serilog and ASP.NET Core: Split Log Data Using Serilog FilterExpression](https://vmsdurano.com/serilog-and-asp-net-core-split-log-data-using-filterexpression/)
- FromLogContext, MessageTemplate(HashCode) | https://blog.datalust.co/serilog-tutorial/
---
- [전문가 | Nicholas Blumhardt](https://nblumhardt.com/)
- [전문가 | Andrew Lock](https://andrewlock.net/tag/logging/)
- [Enricher 만들기(Creating custom serilog enrichers)](https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/)
- [환경 설정 기반에서 동적 Level 처리하기(Changing Serilog Minimum level without application restart on .NET Framework and Core)](https://swimburger.net/blog/dotnet/changing-serilog-minimum-level-without-application-restart-on-dotnet-framework-and-core)
- https://benfoster.io/blog/serilog-best-practices/
- [Elastic.CommonSchema.Serilog.Tests](https://github.com/elastic/ecs-dotnet/tree/master/tests/Elastic.CommonSchema.Serilog.Tests)
- [Elasticsearch.Extensions.Logging.IntegrationTests](https://github.com/elastic/ecs-dotnet/tree/master/tests/Elasticsearch.Extensions.Logging.IntegrationTests)
- https://www.devground.co/blog/posts/serilog-sending-logs-to-logstash/
- https://medium.com/@letienthanh0212/building-logging-system-in-microservice-architecture-with-elk-stack-and-serilog-net-core-part-2-2643dbbf3c2c
- https://dev.to/hasdrubal/structure-logging-with-serilog-and-seq-and-elasticsearch-under-docker-16dk
- https://oksala.net/2020/01/24/configure-serilog-with-logstash-and-elasticsearch/
- https://github.com/tsimbalar/serilog-settings-comparison/blob/master/docs/README.md
- https://m.youtube.com/watch?v=f3pposukOSE&feature=youtu.be
- https://github.com/datalust/clef-tool/releases
- https://github.com/serilog/serilog-expressions
  - [x] clef -i log-20170509.clef
  - [ ] clef -i log-20170509.clef --filter="Version > 100"
  - [x] clef -i log-20170509.clef --format-json
  - [x] clef -i log-20170509.clef --format-template="[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] {Message}{NewLine}"
  - [x] clef -i log-20170509.clef -o log-20170509.txt
- https://github.com/warrenbuckley/Compact-Log-Format-Viewer/releases
- http://blog.romanpavlov.me/logging-serilog-elk/
- [Writing logs to Elasticsearch with Fluentd using Serilog in ASP.NET Core](https://andrewlock.net/writing-logs-to-elasticsearch-with-fluentd-using-serilog-in-asp-net-core/)
- https://blumhardt2.rssing.com/chan-6339977/latest.php
- https://medium.com/oldbeedev/c-how-to-monitor-cpu-memory-disk-usage-in-windows-a06fc2f05ad5
- https://github.com/serilog/serilog/wiki/Provided-Sinks
- https://blog.datalust.co/serilog-tutorial/
- http://merbla.com/2018/04/25/exploring-serilog-v2---using-the-http-client-factory/
- https://www.honeycomb.io/blog/simple-structured-logging-with-nlog/

<br/>

## Collectbeat
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