using FluentAssertions;
using System;
using Xunit;

namespace Step05_MultipleCodeCoverage3.UnitTests
{
    public class Class3Spec
    {
        [Fact]
        public void Method_DoseSomething()
        {
            // Assert
            var sut = new Class3();

            // Act
            var actual = sut.Method();

            // Assert
            actual.Should().Be(1);
        }
    }
}
