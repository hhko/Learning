using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using PrimitiveObsession.Stage2;
using System;
using Xunit;
using static PrimitiveObsession.Stage2.Calculate;
namespace PrimitiveObsession.Tests
{
    public class Stage2CalculateSpec
    {
        [Fact]
        public void ShouldCalculateRiskProfile()
        {
            // Arrange

            // Act
            Risk low = CalculateRiskProfile(30);
            Risk medium = CalculateRiskProfile(70);
            Action exp = () => CalculateRiskProfile(10000);

            // Assert
            low.Should().Be(Risk.Low);
            medium.Should().Be(Risk.Medium);
            exp.Should()
                .Throw<ArgumentException>()
                .WithMessage("10000 is not valid age");
        }
    }
}
