using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class NumberTests
    {
        [Fact]
        public void Create_Int()
        {
            // Arrange
            var sut = new IntCalculator();
            var fixture = new Fixture();

            // Act
            sut.Subtract(fixture.Create<int>());

            // Assert
            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void Create_Decimal()
        {
            // Arrange
            var sut = new DecimalCalculator();
            var fixture = new Fixture();

            // Act
            sut.Subtract(fixture.Create<decimal>());

            // Assert
            Assert.True(sut.Value < 0);
        }
    }
}
