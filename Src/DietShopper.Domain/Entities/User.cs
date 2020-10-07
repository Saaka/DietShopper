using System;
using DietShopper.Common.Constants.Validation;
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

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            ValidateUserGuid();
            ValidateDisplayName();
            ValidateImageUrl();
        }

        private void ValidateUserGuid()
        {
            if (UserGuid.Equals(Guid.Empty))
                throw new DomainException(ExceptionCode.UserGuidRequired);
        }

        private void ValidateDisplayName()
        {
            if (string.IsNullOrWhiteSpace(DisplayName))
                throw new DomainException(ExceptionCode.UserDisplayNameRequired);
            if (DisplayName.Length > UserValidationConstants.DisplayNameMaxLength)
                throw new DomainException(ExceptionCode.UserDisplayNameTooLong);
        }

        private void ValidateImageUrl()
        {
            if (string.IsNullOrWhiteSpace(ImageUrl))
                throw new DomainException(ExceptionCode.UserImageUrlRequired);
            if (ImageUrl.Length > UserValidationConstants.ImageUrlMaxLength)
                throw new DomainException(ExceptionCode.UserImageUrlTooLong);
        }
    }
}