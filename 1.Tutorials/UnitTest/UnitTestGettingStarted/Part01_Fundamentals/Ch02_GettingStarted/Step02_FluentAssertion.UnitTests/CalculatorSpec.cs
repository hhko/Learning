using System;
using Xunit;
using FluentAssertions;

namespace Step02_FluentAssertion.Tests
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

            //=====================
            // Assert 변경 전
            //=====================
            Assert.Equal(7, actual);
            
            //Assert.Equal(actual, 7);
            // Warning xUnit2000
            //   The literal or constant value 7 should be passed as the 'expected' argument in the call 
            //   to 'Assert.Equal(expected, actual)' 
            //   in method 'Should_Add' on type 'CalculatorSpec'.Step02_FluentAssertion.Tests

            //=====================
            // Assert 변경 후
            //=====================
            //
            // FluentAssertions 패키지는 자연어 형태의 코드를 구현을 제공한다.
            //
            // "주어(Subject) should be 명사." 문장은 '주어'와 '명사' Equal 관계를 제공한다.
            //
            // actual.Should().Be(7);       // 프로그래밍
            // => The actual should be 7.   // 자연어
            //
            actual.Should().Be(7);
        }
    }
}
