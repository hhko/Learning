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
            int result = calc.Add(1, 6);

            //=====================
            // Assert 변경 전
            //=====================
            Assert.Equal(7, result);
            Assert.Equal(result, 7);
            // Warning xUnit2000
            //   The literal or constant value 7 should be passed as the 'expected' argument in the call 
            //   to 'Assert.Equal(expected, actual)' 
            //   in method 'Should_Add' on type 'CalculatorSpec'.Step02_FluentAssertion.Tests

            //=====================
            // Assert 변경 후
            //=====================
            //
            // Fluetn Assert: 영어 문장 쓰듯 구현 한다.
            //
            // Should는 의무를 뜻하는 조동사다.
            //
            // result.Should().Be(7);       // 프로그래밍
            // => The result should be 7.   // 영문장
            //
            result.Should().Be(7);
        }
    }
}
