using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class DateAndTimeTests
    {
        [Fact]
        public void Create_DateTime()
        {
            // Arrange
            var fixture = new Fixture();
            DateTime logTime = fixture.Create<DateTime>();

            // Act
            LogMessage actual = LogMessageCreator.Creaste(fixture.Create<string>(), logTime);

            // Assert
            Assert.Equal(logTime.Year, actual.Year);
        }

        [Fact]
        public void Create_TimeSpan()
        {
            // Arrange
            var fixture = new Fixture();
            TimeSpan timeSpan = fixture.Create<TimeSpan>();

            // Act

            // Assert
        }
    }
}
