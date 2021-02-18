using Microsoft.Extensions.Logging;     // ILoggerFactory
using OpenTracing;                      // ITracer, ISpan
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Step1
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
            ISpan span = _tracer.BuildSpan("say-hello").Start();

            var msg = FormatHello(span, helloTo);
            PrintHello(span, msg);

            span.Finish();
        }

        private string FormatHello(ISpan rootSpan, string helloTo)
        {
            // 자식 Span 만들기
            ISpan span = _tracer.BuildSpan("format-string")
                .AsChildOf(rootSpan)
                .Start();

            try
            {
                // Span 로그
                string msg = GreetingFor(helloTo);
                span.Log(new Dictionary<string, object>
                {
                    [LogFields.Event] = "string.Format",
                    ["value"] = msg
                });

                return msg;
            }
            finally
            {
                span.Finish();
            }
        }

        private void PrintHello(ISpan rootSpan, string helloTo)
        {
            // 자식 Span 만들기
            ISpan span = _tracer.BuildSpan("print-string")
                .AsChildOf(rootSpan)
                .Start();

            try
            {
                _logger.LogInformation(helloTo);

                // Span 로그
                span.Log(helloTo);
            }
            finally
            {
                span.Finish();
            }
        }

        [Pure]
        private string GreetingFor(string helloTo)
        {
            return $"Hello, {helloTo}!";
        }
    }
}