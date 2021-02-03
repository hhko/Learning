using System;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class StringTest
    {
        [Fact]
        public void Create_BasicStrings()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new NameJoiner();

            // Creates an anonymous variable of the requested type.
            // public static T Create<T>(this ISpecimenBuilder builder);
            var firstName = fixture.Create<string>();
            var lastName = fixture.Create<string>();

            // Act
            var actual = sut.Join(firstName, lastName);

            // Assert
            Assert.Equal(firstName + ' ' + lastName, actual);
        }

        [Fact]
        public void Create_BasicStrings_With_AdditionalInformation()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new NameJoiner();

            // Creates an anonymous object, potentially using the supplied seed as additional information when creating the object.
            // public static T Create<T>(this ISpecimenBuilder builder, T seed);
            var firstName = fixture.Create("First_");
            var lastName = fixture.Create("Last_");

            // Act
            var actual = sut.Join(firstName, lastName);

            // Assert
            Assert.Equal(firstName + ' ' + lastName, actual);
        }
    }
}
