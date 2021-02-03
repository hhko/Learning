using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using PrimitiveObsession.Stage3;
using System;
using Xunit;
using static PrimitiveObsession.Stage3.Calculate;
namespace PrimitiveObsession.Tests
{
    public class Stage3CalculateSpec
    {
        [Fact]
        public void ShouldCalculateRiskProfile()
        {
            // Arrange

            // Act
            Risk low = CalculateRiskProfile(new Stage3.Age(30));
            Risk medium = CalculateRiskProfile(new Stage3.Age(70));
            Action exp = () => CalculateRiskProfile(new Stage3.Age(10000));

            // Assert
            low.Should().Be(Risk.Low);
            medium.Should().Be(Risk.Medium);
            exp.Should()
                .Throw<ArgumentException>()
                .WithMessage("10000 is not valid age");
        }
    }
}
