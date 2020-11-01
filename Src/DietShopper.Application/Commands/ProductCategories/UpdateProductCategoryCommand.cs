using System;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class UpdateProductCategoryCommand : Request<ProductCategoryDto>
    {
        public Guid ProductCategoryGuid { get; set; }
        public string Name { get; }

        public UpdateProductCategoryCommand(Guid productCategoryGuid, string name)
            => (ProductCategoryGuid, Name) = (productCategoryGuid, name);
    }
}