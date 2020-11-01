using System;
using System.Collections.Generic;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Products
{
    public class CreateProductCommand : Request<ProductDto>
    {
        public string Name { get; }
        public string ShortName { get; }
        public string Description { get; }
        public Guid ProductCategoryGuid { get; }
        public int Calories { get; }
        public decimal Carbohydrates { get; }
        public decimal Proteins { get; }
        public decimal Fat { get; }
        public decimal SaturatedFat { get; }
        public List<ProductMeasureData> ProductMeasures { get; }

        public CreateProductCommand(string name, string shortName, string description, Guid productCategoryGuid, int calories, decimal carbohydrates, decimal proteins, decimal fat,
            decimal saturatedFat, List<ProductMeasureData> productMeasures)
        {
            Name = name;
            ShortName = shortName;
            Description = description;
            ProductCategoryGuid = productCategoryGuid;
            Calories = calories;
            Carbohydrates = carbohydrates;
            Proteins = proteins;
            Fat = fat;
            SaturatedFat = saturatedFat;
            ProductMeasures = productMeasures ?? new List<ProductMeasureData>();
        }

        public class ProductMeasureData
        {
            public Guid MeasureGuid { get; }
            public decimal ValueInGrams { get; }
            public bool IsDefault { get; set; }

            public ProductMeasureData(Guid measureGuid, decimal valueInGrams, bool isDefault)
            {
                MeasureGuid = measureGuid;
                ValueInGrams = valueInGrams;
                IsDefault = isDefault;
            }
        }
    }
}