using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using Ch2.CreatingFixture.Sequence;

namespace Ch2.CreatingFixture.Tests
{
    public class SequenceTests
    {
        [Fact]
        public void Create_Sequence_Of_Strings()
        {
            // Arrange
            var fixture = new Fixture();

            // 기본적으로 3개를 생성한다.
            // public static IEnumerable<T> CreateMany<T>(this ISpecimenBuilder builder);
            IEnumerable<string> messages = fixture.CreateMany<string>();

            // Act

            // Assert
        }

        [Fact]
        public void Create_Sequence_Of_ExplicitNumber()
        {
            // Arrange
            var fixture = new Fixture();

            // 데이터 생성 갯수를 지정할 수 있다.
            // public static IEnumerable<T> CreateMany<T>(this ISpecimenBuilder builder, int count);
            IEnumerable<string> messages = fixture.CreateMany<string>(6);

            // Act

            // Assert
        }

        [Fact]
        public void Add_To_ExistingSequence()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();

            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection);
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, int repeatCount)
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, Func<T> creator);
            fixture.AddManyTo(sut.Messages);

            // Act

            // Assert
        }

        [Fact]
        public void Add_To_ExistingSequence_ExplicitNumber()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();

            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection);
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, int repeatCount)
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, Func<T> creator);
            fixture.AddManyTo(sut.Messages, 10);

            // Act
            sut.WriteMessages();

            // Assert
            Assert.Equal(10, sut.MessagesWritten);
        }

        [Fact]
        public void Add_To_ExistingSequence_With_Creator()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();

            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection);
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, int repeatCount)
            // public static void AddManyTo<T>(this IFixture fixture, ICollection<T> collection, Func<T> creator);
            fixture.AddManyTo(sut.Messages, () => "Hi");

            // Act

            // Assert
        }
    }
}
