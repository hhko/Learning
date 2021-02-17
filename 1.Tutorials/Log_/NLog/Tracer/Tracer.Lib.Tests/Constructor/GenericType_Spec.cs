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
    public class GenericType_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Constructor()
        {
            // Arrange 

            // Act
            GenericType<Foo> genericType = new GenericType<Foo>();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.GenericType`1[Tracer.Lib.Foo] Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.GenericType`1[Tracer.Lib.Foo] Returned from .ctor() (). Time taken:");
        }
    }
}
