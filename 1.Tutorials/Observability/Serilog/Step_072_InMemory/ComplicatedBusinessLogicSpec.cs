using Serilog;
using Serilog.Events;
using Serilog.Sinks.InMemory;
using Serilog.Sinks.InMemory.Assertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Step_072_InMemory
{
    public class ComplicatedBusinessLogicSpec
    {
        [Fact]
        public void GivenInputOfFiveCharacters_MessageIsLogged()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.InMemory()
                .CreateLogger();

            var logic = new ComplicatedBusinessLogic(logger);

            logic.FirstTenCharacters("12345");

            // Use the static Instance property to access the in-memory sink
            var x1 = InMemorySink.Instance
                .Should()
                    .HaveMessage("Input is {Count} characters long {Foo}")
                    .Once()
                    //.Appearing().Once()                     // 로그 호출 횟수      //.Appearing().Times(1);
                    .WithLevel(LogEventLevel.Information);   // 로그 수준

            x1
                    .WithProperty("Count").WithValue(5);    // 속성 값
              
            x1.WithProperty("Foo").WithValue(2);    // 속성 값
        }

        // TODO 속성 1개
        // TODO 속성 n개
        // TODO NotHaveMessage
        // TODO Containing
    }
}
