using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using PrimitiveObsession.Stage4;
using System;
using Xunit;
using static PrimitiveObsession.Stage4.Calculate;

namespace PrimitiveObsession.Tests
{
    public class Stage4CalculateSpec
    {
        [Fact]
        public void ShouldCalculateRiskProfile()
        {
            // Arrange

            // Act
            Risk low = CalculateRiskProfile(new Stage4.Age(30));
            Risk medium = CalculateRiskProfile(new Stage4.Age(70));
            Action exp = () => CalculateRiskProfile(new Stage4.Age(10000));

            // Assert
            low.Should().Be(Risk.Low);
            medium.Should().Be(Risk.Medium);
            exp.Should()
                .Throw<ArgumentException>()
                .WithMessage("10000 is not valid age");
        }
    }
}
