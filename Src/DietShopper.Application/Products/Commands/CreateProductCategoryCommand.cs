using System;
using DietShopper.Application.Products.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands
{
    public class CreateProductCategoryCommand : Request<ProductCategoryDto>
    {
        public string Name { get; set; }
    }
}