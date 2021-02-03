using FluentAssertions;
using ManagingSideEffects.Stage3;
using System;
using Xunit;

namespace ManagingSideEffects.Tests
{
    public class PureCompositionSpec
    {
        [Fact]
        public void Create_GreetingFor_Stantance()
        {
            // Arrange

            // Act
            string actual = StringExt.GreetingFor("Foo");

            // Assert
            actual.Should().Be("Hello Foo");
        }
    }
}
