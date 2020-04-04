using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using PrimitiveObsession.Stage1;
using System;
using Xunit;
using static PrimitiveObsession.Stage1.Calculate;

namespace PrimitiveObsession.Tests
{

    public class Stage1CalculateSpec
    {
        [Fact]
        public void ShouldCalculateRiskProfile()
        {
            // Arrange

            // Act
            Risk low = CalculateRiskProfile(30);
            Risk medium = CalculateRiskProfile(70);
            Action exp = () => CalculateRiskProfile("Hello");

            // Assert
            low.Should().Be(Risk.Low);
            medium.Should().Be(Risk.Medium);
            exp.Should()
                .Throw<RuntimeBinderException>()
                .WithMessage("Operator '<' cannot be applied to operands of type 'string' and 'int'");
        }
    }
}