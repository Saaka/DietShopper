using System;
using System.Collections.Generic;

namespace DietShopper.Application.Queries.Products.Models
{
    public class CompleteProductQueryResultDto
    {
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public Guid ProductCategoryGuid { get; set; }
        public Guid DefaultMeasureGuid { get; set; }
        public bool IsActive { get; set; }
        public int Calories { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }
        public List<ProductMeasureDetailedDto> ProductMeasures { get; set; } = new List<ProductMeasureDetailedDto>();
    }
}