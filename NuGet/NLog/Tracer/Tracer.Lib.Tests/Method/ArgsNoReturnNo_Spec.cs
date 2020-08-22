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
    public class ArgsNoReturnNo_Spec : LogSpec
    {
        //
        // 입출력 모두가 없을 때
        // 
        [Fact]
        public void ShouldTrace_ArgsNoReturnNo()
        {
            // Arrange 
            ArgsNoReturnNo argsNoReturnNo = new ArgsNoReturnNo();

            // Act
            argsNoReturnNo.CallMe();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturnNo Entered into CallMe().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturnNo Returned from CallMe() (). Time taken:");
        }
    }
}
