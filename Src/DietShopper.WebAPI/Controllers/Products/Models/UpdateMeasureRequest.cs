using System;

namespace DietShopper.WebAPI.Controllers.Products.Models
{
    public class UpdateMeasureRequest
    {
        public Guid MeasureGuid { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool IsWeight { get; set; }
        public decimal? ValueInGrams { get; set; }
    }
}