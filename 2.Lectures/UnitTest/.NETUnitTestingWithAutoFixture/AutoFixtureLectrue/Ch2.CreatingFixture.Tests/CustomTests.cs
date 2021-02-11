using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class CustomTests
    {
        [Fact]
        public void Create_ManualAnonymousTestData()
        {
            // Arrange
            var sut = new EmailMessageBuffer();
            var message = new EmailMessage(
                toAddress: "xyz@gooogle.com",
                messageBody: "Hello, hope you are well",
                isImportant: false);

            message.Subject = "Hi";

            // Act
            sut.Add(message);

            // Assert
            Assert.Single(sut.Emails);
        }

        [Fact]
        public void Create_AutomaticalAnonymousTestData()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new EmailMessageBuffer();

            // 생성자의 기본타입 매개변수는 자동으로 주입한다.
            // string 값에 접두사(Prefix)를 자동으로 추가한다.
            var message = fixture.Create<EmailMessage>();
            // +Id	                {ce30fbdb-8cdd-4e03-ad98-c1911b567b85}, System.Guid
            // IsImportant	        false, bool
            // MessageBody	        "messageBodyb0238ae0-fa72-418c-be95-b6428048813e", string
            // MessageType	        Unspecified, Ch2.CreatingFixture.EmailMessageType
            // SomePrivateProperty	null, string
            // SomePublicField	    "SomePublicField0f1c2f1c-b9fb-4ea2-9f2a-d4e17ed7b6c1", string
            // SomePublicProperty	"SomePublicProperty8181b948-e3ad-413d-a1cd-87092df4ecae", string
            // ToAddress	        "ToAddressebddc868-2a7b-4a31-a25a-9854c515521f", string
            // _somePrivateField	null, string

            // Act
            sut.Add(message);

            // Assert
            Assert.Single(sut.Emails);
        }
    }
}
