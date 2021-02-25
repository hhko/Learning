﻿﻿# Serilog Tutorial

## NuGet 패키지
- [x] Serilog
- [x] Serilog.Sinks.Console
- [x] Serilog.Sinks.File
- [x] Destructurama.Attributed
- [x] Serilog.Formatting.Compact 
  - CKEF(Compact Log Event Format Tool)
- [x] Serilog.Exceptions
- [x] Serilog.Formatting.Elasticsearch
- [x] Elastic.CommonSchema.Serilog
- [x] Serilog.Settings.Configuration
  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.Configuration.FileExtensions
  - Microsoft.Extensions.Configuration.Json
- [x] Serilog.Settings.AppSettings
- [x] Serilog.Sinks.Http
  - [Kibana Query Language](https://www.elastic.co/guide/en/kibana/7.9/kuery-query.html)
- [x] SerilogTimings
- [x] Serilog.Enrichers.Environment
- [x] Serilog.Enrichers.AssemblyName
- [x] Serilog.Enrichers.Process
- [x] Serilog.Enrichers.Thread
- [x] Serilog.Sinks.Notepad
- [x] Serilog.Sinks.RichTextBox.Wpf
- [ ] Serilog.Sinks.Debug
---
- [ ] ExcelDna.Diagnostics.Serilog
---
- [ ] Serilog.Enrichers.Context
- [ ] Serilog.Enrichers.Memory
- [ ] ~~Serilog.Enrichers.CorrelationId~~ : 출력 안됨
- [ ] ~~Serilog.Enrichers.Span~~ : 출력 안됨(.NET 5.0 이상)
---
- [ ] Serilog.Sinks.Map
- [ ] Serilog.Sinks.Async
- [ ] Serilog.Sinks.Elasticsearch
- [ ] Serilog.Sinks.PeriodicBatching
- [ ] Serilog.Sinks.TestCorrelator
- [ ] Serilog.Sinks.SQLite, 5.0.0
- [ ] Serilog.Sinks.file-header
- [ ] Serilog.Sinks.file-gzip
- [ ] Serilog.Sinks.file-archive
- [ ] ~~Serilog.Sinks.RollingFile~~
---
- [ ] Serilog.Extensions.Hosting
- [ ] Serilog.Extensions.Logging
---
- [ ] Serilog.Filters.Expressions
- [ ] ~~Elastic.Apm.SerilogEnricher~~ : 출력 안됨
- [ ] ~~SerilogMetrics~~
- [ ] serilog-generator 
---
- [ ] Serilog.Sinks.XUnit
- [ ] Elastic.Elasticsearch.Xunit
- [ ] Serilog.Enrichers.Process GitHub 단위 테스트 작성 방법 이해
---
- [ ] Serilog.Formatting.Compact.Reader
- [ ] Analogy.LogViewer.Serilog Json

<br/>

## TODO
- Elasticsearch/Kibana 확인
- [ ] 횟수 : 네임스페이스 > 클래스 > 메서드, 수준(Error : 예외 포함)
- [ ] 내용 : 성공/실패
- [ ] 시간
- [ ] 흐름 : 관계?
---  
- [ ] Raw 기본 출력 형식
- [ ] Visual Studio Serilog 확장 도구 https://github.com/Suchiman/SerilogAnalyzer
- [ ] NET 최소 버전
- [ ] { } 표준화?
- [ ] { :? } 형식
- [ ] 로컬 로그 뷰어 CLI
- [ ] 로컬 로그 뷰어 GUI
- [ ] 단위 테스트
- [ ] AuditTo?
- [ ] NuGET
  - Http
  - Async
  - ElasticCommonSchma
- [ ] 사용자 정의 필드, Kafka
- [ ] 사용자 정의
  - Fomrat 사용자 정의 만들기
  - Sink 사용자 정의 만들기
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
- [x] Enrichers 직접 구현 : [Creating custom serilog enrichers](https://www.ctrlaltdan.com/2018/08/14/custom-serilog-enrichers/)
- [x] NotLogged 속성 이용하기 | (https://ranjeet.dev/getting-started-with-serilog/)
- [x] 복수 Logger 만들기 | [Serilog and ASP.NET Core: Split Log Data Using Serilog FilterExpression](https://vmsdurano.com/serilog-and-asp-net-core-split-log-data-using-filterexpression/)
- [x] Logstash에게 메시지 보내기 | https://github.com/FantasticFiasco/serilog-sinks-http-sample-elastic-stack
- [x] MessageTemplate으로 Hash 값 만들기 | https://blog.datalust.co/serilog-tutorial/
- [x] 환경 설정 기반에서 동적 Level 처리하기 | [Changing Serilog Minimum level without application restart on .NET Framework and Core](https://swimburger.net/blog/dotnet/changing-serilog-minimum-level-without-application-restart-on-dotnet-framework-and-core)
---
- [ ] Visual Studio Serilog 확장 도구 https://github.com/Suchiman/SerilogAnalyzer
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
- 예외 처리 : https://hamidmosalla.com/2018/06/19/exception-handling-in-asynchronous-code/

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
