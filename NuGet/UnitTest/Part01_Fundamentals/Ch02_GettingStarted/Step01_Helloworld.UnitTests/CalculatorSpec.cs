using System;
using Xunit;

namespace Step01_Helloworld.Tests
{
    public class CalculatorSpec
    {
        [Fact]
        public void Should_Add()
        {
            // Arrange: 준비
            Calculator calc = new Calculator();

            // Act: 수행
            int actual = calc.Add(1, 6);

            // Assert: 확인
            Assert.Equal(7, actual);
        }
    }
}
