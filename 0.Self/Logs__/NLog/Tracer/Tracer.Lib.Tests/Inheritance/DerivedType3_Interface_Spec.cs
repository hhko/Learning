using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Inheritance;
using Xunit;

namespace Tracer.Lib.Tests.Inheritance
{
    public class DerivedType3_Interface_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Constructor()
        {
            // Arrange 

            // Act
            InterfaceType interfaceDerivedType = new DerivedType3_Interface();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Inheritance.DerivedType3_Interface Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Inheritance.DerivedType3_Interface Returned from .ctor() (). Time taken:");
        }
    }
}
