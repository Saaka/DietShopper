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
            var user = new User(userGuid, "Thomas Anderson", "http://test.com/image", true);

            user.UserId.Should().Be(0);
            user.UserGuid.Should().Be(userGuid);
            user.DisplayName.Should().Be("Thomas Anderson");
            user.ImageUrl.Should().Be("http://test.com/image");
            user.IsAdmin.Should().BeTrue();
        }
    }
}