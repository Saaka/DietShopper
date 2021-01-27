using System;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class UpdateProductCategoryCommand : Request<ProductCategoryDto>, IRequestWithAdminAuthorization
    {
        public Guid ProductCategoryGuid { get; set; }
        public string Name { get; set; }
    }
}