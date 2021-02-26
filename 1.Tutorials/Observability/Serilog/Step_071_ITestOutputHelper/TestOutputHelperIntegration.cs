using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Step_071_ITestOutputHelper
{
    public class TestOutputHelperIntegration
    {
        private ILogger _output;

        public TestOutputHelperIntegration(ITestOutputHelper output)
        {
            // Case 1. "ITestOutputHelper 확장 메서드로 Logger 만들기"는 추천하지 않는다.
            //         why?
            //         Global MinimumLevel을 제어할 수 없다.
            //         Global MinimumLevel은 Information이기 때문에 Debug과 Verbose는 단위 테스트할 수 없다.
            //
            //_output = output
            //    .CreateTestLogger(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");
            //_output = output
            //    .CreateTestLogger(formatter: new JsonFormatter());        // Json 출력

            // Case 2. 직접 Logger 만들기
            // 
            _output = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(testOutputHelper: output, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                //.WriteTo.TestOutput(testOutputHelper: output, formatter: new JsonFormatter())         // Json
                .CreateLogger();
        }

        [Fact]
        public void ExampleUsage()
        {
            _output.Information("Test output to Serilog!");

            Action sketchy = () => throw new Exception("I threw up.");
            var exception = Record.Exception(sketchy);

            _output.Error(exception, "Here is an error.");
            Assert.NotNull(exception);
        }
    }
}
