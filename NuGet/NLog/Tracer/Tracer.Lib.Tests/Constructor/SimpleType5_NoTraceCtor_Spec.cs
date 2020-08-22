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
    public class SimpleType5_NoTraceCtor_Spec : LogSpec
    {
        [Fact]
        public void ShouldNotTrace()
        {
            // Arrange 

            // Act
            SimpleType5_NoTraceCtor simpleType5_NoTraceCtor = new SimpleType5_NoTraceCtor(2020, new List<int> { 1, 2, 3 });

            // Assert
            _memoryTarget.Logs.Count.Should().Be(0);
        }
    }
}
