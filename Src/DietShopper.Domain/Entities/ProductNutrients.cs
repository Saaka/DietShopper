using System;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class ProductNutrients
    {
        public int ProductNutrientsId { get; set; }
        public Guid ProductNutrientsGuid { get; set; }
        public int ProductId { get; set; }
        public int Calories { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }

        public virtual Product Product { get; set; }

        private ProductNutrients() { }

        public ProductNutrients(Guid productNutrientsGuid, int calories, decimal carbohydrates, decimal proteins, decimal fat, decimal saturatedFat)
        {
            ProductNutrientsGuid = productNutrientsGuid;
            Calories = calories;
            Carbohydrates = carbohydrates;
            Proteins = proteins;
            Fat = fat;
            SaturatedFat = saturatedFat;

            ValidateCreation();
        }

        public ProductNutrients SetNutrientsContent(int calories, decimal carbohydrates,
            decimal proteins, decimal fat, decimal saturatedFat)
        {
            ValidateNutrients(calories, carbohydrates, proteins, fat, saturatedFat);
            
            Calories = calories;
            Carbohydrates = carbohydrates;
            Proteins = proteins;
            Fat = fat;
            SaturatedFat = saturatedFat;

            return this;
        }

        private void ValidateCreation()
        {
            if (ProductNutrientsGuid.Equals(Guid.Empty))
                throw new InternalException(ErrorCode.ProductNutrientsGuidRequired);

            ValidateNutrients(Calories, Carbohydrates, Proteins, Fat, SaturatedFat);
        }

        private void ValidateNutrients(int calories, decimal carbohydrates,
            decimal proteins, decimal fat, decimal saturatedFat)
        {
            if (calories < 0)
                throw new DomainException(ErrorCode.CaloriesMustBeGreaterOrEqualZero);
            if (carbohydrates < 0)
                throw new DomainException(ErrorCode.CarbohydratesMustBeGreaterOrEqualZero);
            if (proteins < 0)
                throw new DomainException(ErrorCode.ProteinsMustBeGreaterOrEqualZero);
            if (fat < 0)
                throw new DomainException(ErrorCode.FatMustBeGreaterOrEqualZero);
            if (fat < saturatedFat)
                throw new DomainException(ErrorCode.SaturatedFatContentCantBeGraterThanFatContent);
            if (saturatedFat < 0)
                throw new DomainException(ErrorCode.SaturatedFatMustBeGreaterOrEqualZero);
        }
    }
}