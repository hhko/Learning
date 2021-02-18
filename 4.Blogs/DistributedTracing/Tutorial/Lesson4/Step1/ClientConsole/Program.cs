using Jaeger;
using LessonLib;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Propagation;
using OpenTracing.Tag;
using System;
using System.Collections.Generic;
using System.Net;

namespace ClientConsole
{
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Console.WriteLine("Hello World!");
    //     }
    // }

    internal class Hello
    {
        private readonly ITracer _tracer;
        private readonly ILogger<Hello> _logger;
        private readonly WebClient _webClient = new WebClient();

        private Hello(ITracer tracer, ILoggerFactory loggerFactory)
        {
            _tracer = tracer;
            _logger = loggerFactory.CreateLogger<Hello>();
        }

        private string FormatString(string helloTo)
        {
            using (var scope = _tracer.BuildSpan("format-string").StartActive(true))
            {
                var url = $"https://localhost:5001/api/format/{helloTo}";
                var span = _tracer.ActiveSpan
                    .SetTag(Tags.SpanKind, Tags.SpanKindClient)
                    .SetTag(Tags.HttpMethod, "GET")
                    .SetTag(Tags.HttpUrl, url);

                // SpanKindServer
                // SpanKindClient
                // SpanKindProducer
                // SpanKindConsumer

                var dictionary = new Dictionary<string, string>();

                // 
                // static readonly IFormat<ITextMap> TextMap;           -> TextMapInjectAdapter
                // static readonly IFormat<IHttpHeaders> HttpHeaders;
                // static readonly IFormat<IBinary> Binary
                //
                // void Inject<TCarrier>(ISpanContext spanContext, IFormat<TCarrier> format, TCarrier carrier);
                
                _tracer.Inject(span.Context, BuiltinFormats.HttpHeaders, new TextMapInjectAdapter(dictionary));

                // dictionary
                // Key     "uber-trace-id"
                // Value   "2f023a4cbb039a4b%3Ac8c0105f4211e02b%3A2f023a4cbb039a4b%3A1"

                foreach (var entry in dictionary)
                    _webClient.Headers.Add(entry.Key, entry.Value);
                
                var helloString = _webClient.DownloadString(url);
                scope.Span.Log(new Dictionary<string, object>
                {
                    [LogFields.Event] = "string.Format",
                    ["value"] = helloString
                });
                return helloString;
            }
        }

        private void PrintHello(string helloString)
        {
            //using (var scope = _tracer.BuildSpan("print-hello").StartActive(true))
            using var scope = _tracer.BuildSpan("print-hello").StartActive(true);
            //{
                _logger.LogInformation(helloString);
                scope.Span.Log("WriteLine");
            //}
        }

        private void SayHello(string helloTo, string greeting)
        {
            //using (var scope = _tracer.BuildSpan("say-hello").StartActive(true))
            using var scope = _tracer.BuildSpan("say-hello").StartActive(true);
            //{

                //
                // SetBaggageItem
                //
                scope.Span.SetBaggageItem("greeting", greeting);

                scope.Span.SetTag("hello-to", helloTo);
                var helloString = FormatString(helloTo);
                PrintHello(helloString);
            //}
        }

        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
              throw new ArgumentException("Expecting two arguments, helloTo and greeting");
            }

            //
            // SSL 접속 예외 처리
            // The SSL connection could not be established, 
            // see inner exception.The remote certificate is invalid according to the validation procedure C#
            //
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            using Tracer tracer = Tracing.Init("hello-world", loggerFactory);
            
            new Hello(tracer, loggerFactory).SayHello(args[0], args[1]);
        }
    }
}
