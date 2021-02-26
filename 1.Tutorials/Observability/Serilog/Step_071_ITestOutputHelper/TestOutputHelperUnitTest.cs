using Moq;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Step_071_ITestOutputHelper
{
    public class TestOutputHelperUnitTest
    {
        [Fact]
        public void Emit_ShouldWriteDebugEventWhenMinimumLevelSetToDebug()
        {
            var outputHelper = new Mock<ITestOutputHelper>();
            var formatter = new Mock<ITextFormatter>();

            // Case 1. "ITestOutputHelper 확장 메서드로 Logger 만들기"는 추천하지 않는다.
            //         why?
            //         Global MinimumLevel을 제어할 수 없다.
            //         Global MinimumLevel은 Information이기 때문에 Debug과 Verbose는 단위 테스트할 수 없다.
            //
            //var logger = outputHelper.Object.CreateTestLogger(formatter: formatter.Object, restrictedToMinimumLevel: LogEventLevel.Debug);

            // Case 2. 직접 Logger 만들기
            //
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(outputHelper.Object, formatter.Object, LogEventLevel.Debug)
                .CreateLogger();

            const string message = "Hello";
            logger.Information(message);

            outputHelper.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
            formatter.Verify(x => 
                x.Format(
                    It.Is<LogEvent>(ev => ev.Level == LogEventLevel.Debug && ev.MessageTemplate.Text == message),
                    It.IsAny<TextWriter>()), 
                Times.Once);

            //outputHelper.Verify(x => x.WriteLine(""), Times.Once());
            //outputHelper.Received(1).WriteLine(Arg.Any<string>());

            //formatter.Received(1).Format(
            //    Arg.Is<LogEvent>(ev => ev.Level == LogEventLevel.Debug && ev.MessageTemplate.Text == message),
            //    Arg.Any<StringWriter>());
        }
    }
}
