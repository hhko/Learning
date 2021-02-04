현재 우리는?
1. 텍스트 형식만 있는 로그 내용(정규식 등을 이용한 검색)	-> 구조화
1. 여러 로그 파일														-> 통합
1. 운영 데이터베이스에 로그 저장									-> 분리

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
- [ ] Serilog.Sinks.SQLite, 5.0.0
- [ ] Serilog.Formatting.Compact, 1.1.0


Visual Studio 도구 
- https://github.com/Suchiman/SerilogAnalyzer

사용자 정의 출력(Sinks)  

사용자 정의 데이터(Enrichers)


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
---
- [x] WriteTo
- [x] Destructure
- [x] MinimumLevel
- [ ] ReadFrom
- [ ] Filter
- [ ] Enrich
- [ ] AuditTo


최소 수준 : 전역
최소 수준 : 출력 단위

출력 구분