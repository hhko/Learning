using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class DataAnnotationTests
    {
        [Fact]
        public void Create_DataAnnotation()
        {
            // Arrange
            var fixture = new Fixture();
            
            // Act
            var playerCharacter = fixture.Create<PlayerCharacter>();

            // Assert
            Assert.Equal(20, playerCharacter.RealName.Length);
            Assert.Equal(8, playerCharacter.GameCharacterName.Length);
            Assert.InRange<int>(playerCharacter.CurrentHealth, 0, 100);
        }
    }
}
