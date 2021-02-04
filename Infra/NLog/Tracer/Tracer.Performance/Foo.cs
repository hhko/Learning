using NLog;
using System.Threading;
using TracerAttributes;
using BenchmarkDotNet.Attributes;
using ILogger = NLog.ILogger;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;

namespace Tracer.Performance
{
    public class Foo
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        // 로그가 없는 기본 코드
        [NoTrace]
        [Benchmark(Baseline = true)]
        public void Do()
        {
            Thread.Sleep(100);
        }

        // 로그 출력 코드
        [NoTrace]
        [Benchmark]
        public void Do_NLog_Manual()
        {
            _logger.Trace("Entered into Do_NLog_Manual");

            Thread.Sleep(100);

            _logger.Trace("Returned from Do_NLog_Manual");
        }

        // 로그 출력 자동화 코드
        [Benchmark]
        public void Do_NLog_Auto()
        {
            Thread.Sleep(100);
        }
    }
}
