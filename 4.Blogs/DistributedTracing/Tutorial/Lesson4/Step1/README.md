

Step1. 클라이언트만 Tracing 된다.
Step2. 클라이언트에서 서버까지 명시적으로 Tracing 한다.
Step3. 클라이언트에서 서버까지 암시적으로 Tracing 한다.

// Client
dotnet new console -o .\Lesson3\Step3\ClientConsole
dotnet sln add .\Lesson3\Step3\ClientConsole
C:\DistributedTracing\Tutorial> dotnet add .\Lesson3\Step3\ClientConsole reference .\LessonLib\

dotnet add .\Lesson3\Step3\ClientConsole package Microsoft.Extensions.Logging.Console
dotnet add .\Lesson3\Step3\ClientConsole package Jaeger
dotnet add .\Lesson3\Step3\ClientConsole package OpenTracing

<LagVersion>8.0</LagVersion>

// Server
dotnet new webapi -o .\Lesson3\Step3\ServerWebapi
dotnet sln add .\Lesson3\Step3\ServerWebapi
C:\DistributedTracing\Tutorial> dotnet add .\Lesson3\Step3\ reference .\LessonLib\

dotnet add .\Lesson3\Step3\ServerWebapi package Microsoft.Extensions.Logging.Console
dotnet add .\Lesson3\Step3\ServerWebapi package Jaeger  // Tracer
dotnet add .\Lesson3\Step3\ServerWebapi package OpenTracing.Contrib.NetCore

<LagVersion>8.0</LagVersion>


C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson3\Step3\ServerWebapi\
https://localhost:5001/api/format/foo

// a555dc1159767ff6
//      d38342e595eb03a    format-string
//      3a08122c39eda251    print-hello

// 클라이언트
C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson3\Step3\ClientConsole\
info: Jaeger.Configuration[0]
      Initialized Tracer(ServiceName=hello-world, Version=CSharp-0.3.6.0, Reporter=CompositeReporter(Reporters=RemoteReporter(Sender=UdpSender(UdpTransport=ThriftUdpClientTransport(Client=192.168.99.201:6831))), LoggingReporter(Logger=Microsoft.Extensions.Logging.Logger`1[Jaeger.Reporters.LoggingReporter])), Sampler=ConstSampler(True), IPv4=-1062721647, Tags=[jaeger.version, CSharp-0.3.6.0], [hostname, DESKTOP-SK0NU4O], [ip, 192.168.39.145], ZipkinSharedRpcSpan=False, ExpandExceptionLogs=False, UseTraceId128Bit=False)
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:d38342e595eb03a:a555dc1159767ff6:1 - format-string
info: ClientConsole.Hello[0]
      Hello, hhko!
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:3a08122c39eda251:a555dc1159767ff6:1 - print-hello
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:a555dc1159767ff6:0:1 - say-hello

// 서버
nfo: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:bd3c96822fecfe09:3f23f61cc12c847b:1 - format-controller    
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:e2f52a21f3e49537:3f23f61cc12c847b:1 - Result ObjectResult  
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:3f23f61cc12c847b:4548c4b173b8f672:1 - Action ServerWebapi.Controllers.FormatController/Get
info: Jaeger.Reporters.LoggingReporter[0]
      Span reported: a555dc1159767ff6:4548c4b173b8f672:d38342e595eb03a:1 - HTTP GET