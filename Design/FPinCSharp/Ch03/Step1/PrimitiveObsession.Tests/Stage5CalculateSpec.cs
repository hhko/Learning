using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using PrimitiveObsession.Stage5;
using System;
using Xunit;
using static PrimitiveObsession.Stage5.Calculate;

namespace PrimitiveObsession.Tests
{
    public class Stage5CalculateSpec
    {
        [Fact]
        public void ShouldCalculateRiskProfile()
        {
            // Arrange

            // Act
            Risk low = CalculateRiskProfile(Stage5.Age.Of(30));
            Risk medium = CalculateRiskProfile(Stage5.Age.Of(70));

            // 유효성 검사가 실패하면 기본 값으로 처리한다.
            Risk defaultValue = CalculateRiskProfile(Stage5.Age.Of(10000));

            // Assert
            low.Should().Be(Risk.Low);
            medium.Should().Be(Risk.Medium);
            defaultValue.Should().Be(Risk.Low);
        }
    }
}
