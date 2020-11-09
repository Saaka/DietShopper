using System;

namespace DietShopper.Application.Models
{
    public class ProductDto
    {
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}