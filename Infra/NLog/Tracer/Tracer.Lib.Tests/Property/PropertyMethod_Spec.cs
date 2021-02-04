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

namespace Tracer.Lib.Tests.Property
{
    public class PropertyMethod_Spec : LogSpec
    {
        //
        // Property - get
        //
        [Fact]
        public void ShouldTrace_Get()
        {
            // Arrange 
            PropertyMethod propertyMethod = new PropertyMethod();

            // Act
            int x1 = propertyMethod.IntValueGet;

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Property.PropertyMethod Entered into get_IntValueGet().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Property.PropertyMethod Returned from get_IntValueGet() ($return=1). Time taken:");
        }

        //
        // Property - set
        //
        [Fact]
        public void ShouldTrace_Set()
        {
            // Arrange 
            PropertyMethod propertyMethod = new PropertyMethod();

            // Act
            propertyMethod.IntValueSet = 2020;

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Property.PropertyMethod Entered into set_IntValueSet(Int32) (value=2020).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Property.PropertyMethod Returned from set_IntValueSet(Int32) (). Time taken:");
        }
    }
}
