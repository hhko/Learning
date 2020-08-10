using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using System.Net.Mail;

namespace Ch2.CreatingFixture.Tests
{
    public class MailAddressTests
    {
        [Fact]
        public void Create_EmailAddress()
        {
            // Arrnage
            var fixture = new Fixture();
            
            MailAddress mailAddress = fixture.Create<MailAddress>();
            string address = fixture.Create<MailAddress>().Address;
            
            string localPart = fixture.Create<EmailAddressLocalPart>().LocalPart;
            string domain = fixture.Create<DomainName>().Domain;

            // Act

            // Assert
        }
    }
}
