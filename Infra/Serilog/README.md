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
