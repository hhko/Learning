using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Xunit;

namespace Tracer.Lib.Tests.Constructor
{
    public class SimpleType4_NoTraceArgs_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_NoArgsConstructor()
        {
            // Arrange 

            // Act
            SimpleType4_NoTraceArgs simpleType4_NoTraceArgs = new SimpleType4_NoTraceArgs(2020, new List<int> { 1, 2, 3 });

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.SimpleType4_NoTraceArgs Entered into .ctor(Int32, List`1).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.SimpleType4_NoTraceArgs Returned from .ctor(Int32, List`1) (). Time taken:");
        }
    }
}
