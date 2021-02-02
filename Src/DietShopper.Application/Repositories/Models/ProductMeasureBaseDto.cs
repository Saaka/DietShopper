using System;

namespace DietShopper.Application.Repositories.Models
{
    public class ProductMeasureBaseDto
    {
        public int ProductMeasureId { get; set; }
        public Guid ProductMeasureGuid { get; set; }
        public decimal ValueInGrams { get; set; }
    }
}