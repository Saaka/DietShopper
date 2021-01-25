using System;

namespace DietShopper.Application.Models
{
    public class ProductMeasureDetailedDto
    {
        public Guid ProductMeasureGuid { get; set; }
        public Guid MeasureGuid { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal ValueInGrams { get; set; }
        public bool IsWeight { get; set; }
        public bool IsDefault { get; set; }
    }
}