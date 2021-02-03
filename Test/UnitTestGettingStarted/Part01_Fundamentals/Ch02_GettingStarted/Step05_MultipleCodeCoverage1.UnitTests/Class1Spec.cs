using FluentAssertions;
using System;
using Xunit;

namespace Step05_MultipleCodeCoverage1.UnitTests
{
    public class Class1Spec
    {
        [Fact]
        public void Method_DoseSomething()
        {
            // Assert
            var sut = new Class1();

            // Act
            var actual = sut.Method();

            // Assert
            actual.Should().Be(2020);
        }
    }
}
