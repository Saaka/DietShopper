using System;

namespace DietShopper.Application.Repositories.Models
{
    public class ProductGuidDto
    {
        public int ProductId { get; set; }
        public Guid ProductGuid { get; set; }
    }
}