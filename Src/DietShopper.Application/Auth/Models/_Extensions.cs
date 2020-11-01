using DietShopper.Domain.Entities;

namespace DietShopper.Application.Auth.Models
{
    public static class Extensions
    {
        public static User ToEntity(this AuthorizationUserData userData)
            => new User(userData.UserGuid, userData.DisplayName, userData.Email, userData.ImageUrl, userData.IsAdmin);

        public static User UpdateEntity(this AuthorizationUserData userData, User entity)
            => entity?.Update(userData.DisplayName, userData.ImageUrl, userData.IsAdmin);
    }
}