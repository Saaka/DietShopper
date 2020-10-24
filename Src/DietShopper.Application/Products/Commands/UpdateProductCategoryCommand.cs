using System;
using DietShopper.Application.Products.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands
{
    public class UpdateProductCategoryCommand : Request<ProductCategoryDto>
    {
        public Guid ProductCategoryGuid { get; set; }
        public string Name { get; }

        public UpdateProductCategoryCommand(Guid productCategoryGuid, string name)
            => (ProductCategoryGuid, Name) = (productCategoryGuid, name);
    }
}