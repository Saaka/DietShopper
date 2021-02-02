using System;

namespace DietShopper.Application.Queries.Products.Models
{
    public class SimpleProductQueryResultDto
    {
        public Guid ProductGuid { get; set; }
        public Guid ProductCategoryGuid { get; set; }
        public string Name { get; set; }
        public string ProductCategoryName { get; set; }
        
    }
}