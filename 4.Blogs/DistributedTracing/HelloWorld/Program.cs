using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using OpenTracing;

namespace HelloWorld
{
    public static class Tracing
    {
        public static Tracer Init(string serviceName, ILoggerFactory loggerFactory)
        {
            var samplerConfiguration = new Configuration.SamplerConfiguration(loggerFactory)
                .WithType(ConstSampler.Type)
                .WithParam(1);

            // https://www.jaegertracing.io/docs/1.16/getting-started/
            // Jaeger 서버 IP을 지정한다.
            // 6831	포트
            //  - Protocal: UDP
            //  - Component: Agent
            //  - Function: Accept "jaeger.thrift" over compact thrift protocol
            var reporterConfiguration = new Configuration.ReporterConfiguration(loggerFactory)
                .WithSender(new Configuration.SenderConfiguration(loggerFactory)
                    //.WithAgentHost("192.168.99.201")
                    .WithAgentHost("localhost")     
                    .WithAgentPort(6831))
                .WithLogSpans(true);

            return (Tracer)new Configuration(serviceName, loggerFactory)
                .WithSampler(samplerConfiguration)
                .WithReporter(reporterConfiguration)
                .GetTracer();
        }
    }

    internal class Hello
    {
        private readonly ITracer _tracer;
        private readonly ILogger<Hello> _logger;

        public Hello(ITracer tracer, ILoggerFactory loggerFactory)
        {
            _tracer = tracer;
            _logger = loggerFactory.CreateLogger<Hello>();
        }

        public void SayHello(string helloTo)
        {
            var span = _tracer.BuildSpan("say-hello").Start();
            span.SetTag("hello-to", helloTo);
            var helloString = $"Hello, {helloTo}!";
            span.Log(new Dictionary<string, object>
                {
                    [LogFields.Event] = "string.Format",
                    ["value"] = helloString
                }
            );
            _logger.LogInformation(helloString);
            span.Log("WriteLine");
            span.Finish();
        }

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Expecting one argument");
            }

            // https://docs.microsoft.com/ko-kr/aspnet/core/migration/logging-nonaspnetcore?view=aspnetcore-3.1
            //using (var loggerFactory = new LoggerFactory().AddConsole())
            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                var helloTo = args[0];
                using (var tracer = Tracing.Init("hello-world", loggerFactory))
                {
                    new Hello(tracer, loggerFactory).SayHello(helloTo);
                }
            }
        }
    }
}
