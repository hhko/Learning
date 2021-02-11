using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Xunit;

namespace Tracer.Lib.Tests.Method
{
    public class ArgsReturn_Spec : LogSpec
    {
        //
        // 입출력이 모두 있을 때
        //
        [Fact]
        public void ShouldTrace_ArgsReturn()
        {
            // Arrange 
            ArgsReturn argsReturn = new ArgsReturn();

            // Act
            argsReturn.CallMe(2019);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMe(Int32) (value=2019).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMe(Int32) ($return=2020). Time taken:");
        }

        //
        // 입력 추적 제외
        //
        [Fact]
        public void ShouldTrace_NoTraceArgs()
        {
            // Arrange 
            ArgsReturn argsReturn = new ArgsReturn();

            // Act
            argsReturn.CallMeNoTraceArgs(2019);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceArgs(Int32).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceArgs(Int32) ($return=2020). Time taken:");
        }

        //
        // 출력 추적 제외
        //
        [Fact]
        public void ShouldTrace_NoTraceReturn()
        {
            // Arrange 
            ArgsReturn argsReturn = new ArgsReturn();

            // Act
            argsReturn.CallMeNoTraceReturn(2019);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceReturn(Int32) (value=2019).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceReturn(Int32) (). Time taken:");
        }

        //
        // 입/출력 추적 제외
        //
        [Fact]
        public void ShouldTrace_NoTraceArgsAndReturn()
        {
            // Arrange 
            ArgsReturn argsReturn = new ArgsReturn();

            // Act
            argsReturn.CallMeNoTraceArgsAndReturn(2019);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceArgsAndReturn(Int32).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceArgsAndReturn(Int32) (). Time taken:");
        }
    }
}
