using System;
using Xunit;
using FluentAssertions;

namespace Step03_RunWithoutVS.Tests
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
