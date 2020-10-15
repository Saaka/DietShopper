using DietShopper.Application.Auth.Models;
using DietShopper.Domain.Entities;

namespace DietShopper.Application
{
    public static class Extensions
    {
        public static User ToEntity(this AuthUserData userData)
            => new User(userData.UserGuid, userData.DisplayName, userData.Email, userData.ImageUrl, userData.IsAdmin);

        public static User UpdateEntity(this AuthUserData userData, User entity)
            => entity?.Update(userData.DisplayName, userData.ImageUrl, userData.IsAdmin);
    }
}