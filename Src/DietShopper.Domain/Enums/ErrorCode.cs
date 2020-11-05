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
        // ProductInCategoryRequired = 9,
        ProductNameRequired = 10,
        ProductNameTooLong = 11,
        ProductGuidRequired = 12,
        // ProductShortNameRequired = 13,
        ProductShortNameTooLong = 14,
        ProductDescriptionTooLong = 15,
        DefaultMeasureRequired = 16,
        ProductCategoryRequired = 17,
        MeasureGuidRequired = 18,
        MeasureNameRequired = 19,
        MeasureNameTooLong = 20,
        MeasureSymbolRequired = 21,
        MeasureSymbolTooLong = 22,
        MeasureValueInGramsRequiredForWeightType = 23,
        ProductCategoryNameRequired = 24,
        ProductCategoryNameTooLong = 25,
        ProductCategoryGuidRequired = 26,
        ProductMeasureGuidRequired = 27,
        // ProductRequiredForProductMeasure = 28,
        MeasureRequiredForProductMeasure = 29,
        WeightMustBeGreaterThanZero = 30,
        ProductNutrientsGuidRequired = 31,
        ProductInProductNutrientsRequired = 32,
        CaloriesMustBeGreaterOrEqualZero = 33,
        CarbohydratesMustBeGreaterOrEqualZero = 34,
        ProteinsMustBeGreaterOrEqualZero = 35,
        FatMustBeGreaterOrEqualZero = 36,
        SaturatedFatMustBeGreaterOrEqualZero = 37,
        SaturatedFatContentCantBeGraterThanFatContent = 38,
        ProductNutrientsRequired = 39,
        AuthProviderTokenRequired = 40,
        ProductCategoryNameTaken = 41,
        MeasureNameTaken = 42,
        CantRemoveBaselineMeasure = 43,
        MeasureSymbolTaken = 44,
        ProductMeasureIsRequired = 45,
        MeasureAlreadyAddedForProduct = 46,
        ProductCategoryNotExists = 47,
        ProductNutrientsAlreadyExists = 48,
        MeasureNotExists = 49,
        ProductMeasuresMustBeUnique = 50,
        ProductNameNotUnique = 51,
        ProductShortNameNotUnique = 52,
        ProductNotExists = 53,
    }
}