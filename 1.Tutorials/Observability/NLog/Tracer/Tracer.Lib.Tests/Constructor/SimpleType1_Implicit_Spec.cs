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
    public class SimpleType1_Implicit_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_ImplicitConstructor()
        {
            // Arrange 

            // Act
            SimpleType1_Implicit simpleType1_Implicit = new SimpleType1_Implicit();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.SimpleType1_Implicit Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.SimpleType1_Implicit Returned from .ctor() (). Time taken:");
        }
    }
}
