using System;

namespace DietShopper.WebAPI.Controllers.Products.Models
{
    public class RemoveProductCategoryRequest
    {
        public Guid ProductCategoryGuid { get; set; }
    }
}