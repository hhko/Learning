using FluentAssertions;
using ManagingSideEffects.Stage2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ManagingSideEffects.Tests
{
    public class PureDiscoverySepc
    {
        [Fact]
        public void Create_GreetingFor_Stantance()
        {
            // Arrange
            PureDiscovery sut = new PureDiscovery();

            // Act
            string actual = sut.GreetingFor("Foo");

            // Assert
            actual.Should().Be("Hello Foo");
        }
    }
}
