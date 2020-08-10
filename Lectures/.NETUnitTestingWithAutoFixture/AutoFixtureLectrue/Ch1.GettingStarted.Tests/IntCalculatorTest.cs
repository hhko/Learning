using AutoFixture;
using System;
using Xunit;

namespace Ch1.GettingStarted.Tests
{
    public class IntCalculatorTest
    {
        [Fact]
        public void Create_AnonymousTestData_Manually()
        {
            // Arrnage
            var sut = new IntCalculator();

            // Act
            sut.Subtract(1);

            // Assert
            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void Create_AnonymousTestData_Manually_By_Variable()
        {
            // Arrnage
            var sut = new IntCalculator();
            int aPositiveNumber = 1;

            // Act
            sut.Subtract(aPositiveNumber);

            // Assert
            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void Create_AnonymousTestData_Automatically_By_AutoFixtrue()
        {
            // Arrnage
            var sut = new IntCalculator();
            var fixture = new Fixture();
            int aPositiveNumber = fixture.Create<int>();

            // Act
            sut.Subtract(aPositiveNumber);

            // Assert
            Assert.True(sut.Value < 0);
        }
    }
}
