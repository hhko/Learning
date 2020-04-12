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
    public class SimpleType3_Args_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_ArgsConstructor()
        {
            // Arrange 

            // Act
            SimpleType3_Args simpleType3_Args = new SimpleType3_Args(2020, new List<int> { 1, 2, 3 });

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.SimpleType3_Args Entered into .ctor(Int32, List`1) (x=2020, values=System.Collections.Generic.List`1[System.Int32]).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.SimpleType3_Args Returned from .ctor(Int32, List`1) (). Time taken:");
        }
    }
}
