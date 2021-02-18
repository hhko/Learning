# Lesson 2 - **Step 2**

## 목표

- 자식 Span을 암시적으로 만든다.

## 배움


## 따라하기
1. .NET Core 프로젝트 만들기
   ```shell
    // 프로젝트 만들기
    C:\DistributedTracing\Tutorial> dotnet new console -o .\Lesson2\Step2
    C:\DistributedTracing\Tutorial> dotnet sln add .\Lesson2\Step2\
    C:\DistributedTracing\Tutorial> dotnet add .\Lesson2\Step2\ reference .\LessonLib\

    // 패키지 & 프로젝트 참조하기
    C:\DistributedTracing\Tutorial> dotnet add .\Lesson2\Step2\ package Microsoft.Extensions.Logging.Console
    C:\DistributedTracing\Tutorial> dotnet add .\Lesson2\Step2\ package Jaeger
    C:\DistributedTracing\Tutorial> dotnet add .\Lesson2\Step2\ package OpenTracing
   ```
1. 암시적 자식 Span 만들기
   - **조건: 부모 Span을 알 필요가 없다.**
   - 생성: BuildSpan
   - 시작: StartActive(true)
   - 중지: Dispose
     ```cs
        // 명시적 자식 Span 만들기: 부모 Span을 알아야 한다.
        ISpan span = _tracer.BuildSpan("print-string")
                        .AsChildOf(rootSpan)
                        .Start();

        span.Finish();
        //span.Dispose();

        vs.

        // 암시적 자식 Span 만들기: 부모 Span을 알 필요가 없다.
        using IScope scope = _tracer.BuildSpan("format-string")
                        .StartActive(true);

        // scope.Span.xxx
     ```
1. Span 계층 구조 이해하기
   - 부모 Span: SayHello
   - 자식 Span: FormatHello, PrintHello  
     ![Class Diagram](http://www.plantuml.com/plantuml/proxy?src=https://raw.githubusercontent.com/hhko/Learning-FunctionalProgramming/tree/master/Fundamentals/DistributedTracing/Tutorial/Lesson2/Step2/UMLs/SpanHierarchy.puml)
1. 콘솔 출력 확인하기
   - Span Id을 확인한다: c8a3b0c985a449fa
     ```shell
        C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson2\Step2\ Foo
        info: Jaeger.Configuration[0]
              Initialized Tracer(ServiceName=hello-world, Version=CSharp-0.3.6.0, Reporter=CompositeReporter(Reporters=RemoteReporter(Sender=UdpSender(UdpTransport=ThriftUdpClientTransport(Client=192.168.99.201:6831))), LoggingReporter(Logger=Microsoft.Extensions.Logging.Logger`1[Jaeger.Reporters.LoggingReporter])), Sampler=ConstSampler(True), IPv4=-1062721647, Tags=[jaeger.version, CSharp-0.3.6.0], [hostname, DESKTOP-SK0NU4O], [ip, 192.168.39.145], ZipkinSharedRpcSpan=False, ExpandExceptionLogs=False, UseTraceId128Bit=False)
        info: Jaeger.Reporters.LoggingReporter[0]
              Span reported: c8a3b0c985a449fa:2165d5ad4d5e268e:c8a3b0c985a449fa:1 - format-string
        info: Step2.Hello[0]
              Hello, Foo!
        info: Jaeger.Reporters.LoggingReporter[0]
              Span reported: c8a3b0c985a449fa:1eb8d352a23eb93d:c8a3b0c985a449fa:1 - print-string
        info: Jaeger.Reporters.LoggingReporter[0]
              Span reported: c8a3b0c985a449fa:c8a3b0c985a449fa:0:1 - say-hello
     ```