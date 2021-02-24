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
    public class NestedType_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Constructor()
        {
            // Arrange 

            // Act
            FirstLevel.SecondLevel.DeeplyNested deeplyNested = new FirstLevel.SecondLevel.DeeplyNested();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Constructor.FirstLevel+SecondLevel+DeeplyNested Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Constructor.FirstLevel+SecondLevel+DeeplyNested Returned from .ctor() (). Time taken:");
        }
    }
}
