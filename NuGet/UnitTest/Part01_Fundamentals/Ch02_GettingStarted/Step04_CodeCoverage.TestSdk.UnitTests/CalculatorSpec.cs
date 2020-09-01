using FluentAssertions;
using System;
using Xunit;

namespace Step04_CodeCoverage.TestSdk.UnitTests
{
    public class CalculatorSpec
    {
        [Fact]
        public void Should_Add()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int actual = calc.Add(1, 6);

            // Assert 
            actual.Should().Be(7);
        }
    }
}
