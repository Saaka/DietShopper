using System;

namespace DietShopper.Application.Commands.Products.Models
{
    public class CreateProductMeasureDto
    {
        public Guid MeasureGuid { get; set; }
        public decimal ValueInGrams { get; set; }
        public bool IsDefault { get; set; }
    }
}