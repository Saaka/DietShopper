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
        UserEmailRequired = 7,
        ProductRequired = 8,
        ProductInCategoryRequired = 9,
        ProductNameRequired = 10,
        ProductNameTooLong = 11,
        ProductGuidRequired = 12,
        ProductShortNameRequired = 13,
        ProductShortNameTooLong = 14,
        ProductDescriptionTooLong = 15,
        DefaultMeasureRequired = 16,
        ProductCategoryRequired = 17,
        MeasureGuidRequired = 18,
        MeasureNameRequired = 19,
        MeasureNameTooLong = 20,
        MeasureShortNameRequired = 21,
        MeasureShortNameTooLong = 22,
        MeasureValueInGramsRequiredForWeightType = 23,
        ProductCategoryNameRequired = 24,
        ProductCategoryNameTooLong = 25,
        ProductCategoryGuidRequired = 26,
    }
}