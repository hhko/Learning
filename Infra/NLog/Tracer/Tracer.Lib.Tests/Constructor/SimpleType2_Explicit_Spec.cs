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
    public class SimpleType2_Explicit_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_ExplicitConstructor()
        {
            // Arrange 

            // Act
            SimpleType2_Explicit simpleType2_Explicit = new SimpleType2_Explicit();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.SimpleType2_Explicit Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.SimpleType2_Explicit Returned from .ctor() (). Time taken:");
        }
    }
}
