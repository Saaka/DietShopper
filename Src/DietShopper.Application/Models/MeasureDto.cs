using System;

namespace DietShopper.Application.Models
{
    public class MeasureDto
    {      
        public Guid MeasureGuid { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool IsWeight { get; set; }
        public decimal? ValueInGrams { get; set; }
        public bool IsActive { get; set; }
        public bool IsBaseline { get; set; }
    }
}