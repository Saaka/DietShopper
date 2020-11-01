using System;
using System.Collections.Generic;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Products
{
    public class CreateProductCommand : Request<ProductDto>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Guid ProductCategoryGuid { get; set; }
        public int Calories { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }
        public List<ProductMeasureData> ProductMeasures { get; set; } = new List<ProductMeasureData>();

        public class ProductMeasureData
        {
            public Guid MeasureGuid { get; set; }
            public decimal ValueInGrams { get; set; }
            public bool IsDefault { get; set; }
        }
    }
}