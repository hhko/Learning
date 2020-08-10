using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class EnumAndGuidTests
    {
        [Fact]
        public void Create_Guid()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new EmailMessage(
                toAddress: fixture.Create<string>(),
                messageBody: fixture.Create<string>(),
                isImportant: fixture.Create<bool>());

            sut.Id = fixture.Create<Guid>();

            // Act

            // Assert
        }

        [Fact]
        public void Create_Enum()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new EmailMessage(
                toAddress: fixture.Create<string>(),
                messageBody: fixture.Create<string>(),
                isImportant: fixture.Create<bool>());

            sut.Id = fixture.Create<Guid>();
            sut.MessageType = fixture.Create<EmailMessageType>();
            
            // Act

            // Assert
        }

        [Fact]
        public void Create_Object()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = fixture.Create<EmailMessage>();

            // Act

            // Assert
        }
    }
}
