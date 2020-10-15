using System;
using DietShopper.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DietShopper.Domain.UnitTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void Should_Have_Values_Set_In_Constructor()
        {
            var userGuid = Guid.NewGuid();
            var user = new User(userGuid, "Thomas Anderson", "neo@gmail.com", "http://test.com/image", false);

            user.UserId.Should().Be(0);
            user.UserGuid.Should().Be(userGuid);
            user.DisplayName.Should().Be("Thomas Anderson");
            user.ImageUrl.Should().Be("http://test.com/image");
            user.IsAdmin.Should().BeFalse();
            user.Email.Should().Be("neo@gmail.com");
        }
        
        [Fact]
        public void Should_Have_Values_Set_After_Update()
        {
            var userGuid = Guid.NewGuid();
            var user = new User(userGuid, "Thomas Anderson", "neo@gmail.com", "http://test.com/image", false);
            user.Update("Neo", "http://test.com/image2", true);

            user.UserId.Should().Be(0);
            user.UserGuid.Should().Be(userGuid);
            user.DisplayName.Should().Be("Neo");
            user.ImageUrl.Should().Be("http://test.com/image2");
            user.IsAdmin.Should().BeTrue();
            user.Email.Should().Be("neo@gmail.com");
        }
    }
}