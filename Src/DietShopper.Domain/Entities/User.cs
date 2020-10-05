using System;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public Guid UserGuid { get; private set; }
        public string DisplayName { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsAdmin { get; private set; }

        private User()
        {
        }

        public User(Guid userGuid, string displayName, string imageUrl, bool isAdmin = false)
        {
            UserGuid = userGuid;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            IsAdmin = isAdmin;

            Validate();
        }

        private void Validate()
        {
            if (UserGuid.Equals(Guid.Empty))
                throw new DomainException(ExceptionCode.UserGuidRequired);
            if (string.IsNullOrWhiteSpace(DisplayName))
                throw new DomainException(ExceptionCode.UserDisplayNameRequired);
            if (string.IsNullOrWhiteSpace(ImageUrl))
                throw new DomainException(ExceptionCode.UserImageUrlRequired);
        }
    }
}