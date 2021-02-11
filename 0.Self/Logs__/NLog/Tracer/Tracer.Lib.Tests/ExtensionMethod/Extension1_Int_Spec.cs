using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Tracer.Lib.Property;
using Xunit;
using Tracer.Lib.ExtensionMethod;

namespace Tracer.Lib.Tests.ExtensionMethod
{
    public class Extension1_Int_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace()
        {
            // Arrange 

            // Act
            2019.Do(1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.ExtensionMethod.Extension1_Int Entered into Do(Int32, Int32) (self=2019, value=1).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.ExtensionMethod.Extension1_Int Returned from Do(Int32, Int32) ($return=2020). Time taken:");
        }
    }
}
