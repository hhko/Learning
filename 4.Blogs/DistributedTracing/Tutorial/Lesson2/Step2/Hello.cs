using Microsoft.Extensions.Logging;     // ILoggerFactory
using OpenTracing;                      // ITracer, ISpan
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Step2
{
    public class Hello
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
            // IDispose 
            //  |
            // ISpan
            //  |
            // IScope 
            using IScope span = _tracer.BuildSpan("say-hello")
                .StartActive(true);

            var msg = FormatHello(helloTo);
            PrintHello(msg);
        }

        private string FormatHello(string helloTo)
        {
            // 자식 Span 만들기
            using IScope scope = _tracer.BuildSpan("format-string")
                .StartActive(true);

            // Span 로그
            string msg = GreetingFor(helloTo);
            scope.Span.Log(new Dictionary<string, object>
            {
                [LogFields.Event] = "string.Format",
                ["value"] = msg
            });

            return msg;
        }

        private void PrintHello(string helloTo)
        {
            // 자식 Span 만들기
            using IScope scope = _tracer.BuildSpan("print-string")
                .StartActive(true);

            _logger.LogInformation(helloTo);

            // Span 로그
            scope.Span.Log(helloTo);
        }

        [Pure]
        private string GreetingFor(string helloTo)
        {
            return $"Hello, {helloTo}!";
        }
    }
}