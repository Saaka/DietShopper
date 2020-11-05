using System;

namespace DietShopper.Application.Models
{
    public class ProductMeasureDto
    {
        public Guid ProductMeasureGuid { get; set; }
        public Guid MeasureGuid { get; set; }
        public decimal ValueInGrams { get; set; }
    }
}