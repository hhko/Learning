using System;
using Xunit;
using FluentAssertions;

namespace Step_01_Identity.UnitTests
{
    public class UserSpecs
    {
        [Fact]
        public void ShouldIdentifyUsers()
        {
            var user1 = new User(new UserId("1"), "고길동");
            var user2 = new User(new UserId("2"), "고길동");

            var compsre = user1.Equals(user2);

            compsre.Should().BeFalse();
        }

        [Fact]
        public void ShouldChangeName()
        {
            var user = new User(new UserId("1"), "고길동");

            user.ChangeUserName("고둘리");

            user.Name.Should().Be("고둘리");
        }
    }
}
