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
    public class DerivedType2_Abstract_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Constructor()
        {
            // Arrange 

            // Act
            AbstractType abstractDerivedType = new DerivedType2_Abstract();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Inheritance.DerivedType2_Abstract Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Inheritance.DerivedType2_Abstract Returned from .ctor() (). Time taken:");
        }
    }
}
