using FluentAssertions;
using System;
using Xunit;

namespace Step05_MultipleCodeCoverage2.UnitTests
{
    public class Class2Spec
    {
        [Fact]
        public void Method_DoseSomething()
        {
            // Assert
            var sut = new Class2();

            // Act
            var actual = sut.Method();

            // Assert
            actual.Should().Be(9);
        }
    }
}
