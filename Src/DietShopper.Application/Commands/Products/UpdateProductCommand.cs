using System;
using System.Collections.Generic;
using DietShopper.Application.Commands.Products.Models;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Products
{
    public class UpdateProductCommand : Request<ProductDto>
    {
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Guid ProductCategoryGuid { get; set; }
        public int Calories { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }
        public List<UpdateProductMeasureDto> ProductMeasures { get; set; } = new List<UpdateProductMeasureDto>();
    }
}