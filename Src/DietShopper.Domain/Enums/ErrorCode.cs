namespace DietShopper.Domain.Enums
{
    public enum ErrorCode
    {
        ValidationError = 1,
        UserGuidRequired = 2,
        UserDisplayNameRequired = 3,
        UserImageUrlRequired = 4,
        UserDisplayNameTooLong = 5,
        UserImageUrlTooLong = 6,
    }
}