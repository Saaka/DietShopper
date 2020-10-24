using System;

namespace DietShopper.WebAPI.Controllers.Products.Models
{
    public class UpdateProductCategoryRequest
    {
        public Guid ProductCategoryGuid { get; set; }
        public string Name { get; set; }
    }
}