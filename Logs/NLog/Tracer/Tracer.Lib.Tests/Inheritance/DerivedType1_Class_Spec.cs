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
    public class DerivedType1_Class_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Constructor()
        {
            // Arrange 

            // Act
            ClassType classDerivedType = new DerivedType1_Class();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Inheritance.DerivedType1_Class Entered into .ctor().");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.Inheritance.ClassType Entered into .ctor().");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.Inheritance.ClassType Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Inheritance.DerivedType1_Class Returned from .ctor() (). Time taken:");
        }
    }
}
