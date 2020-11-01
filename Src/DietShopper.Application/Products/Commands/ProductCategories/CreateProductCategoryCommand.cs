using DietShopper.Application.Products.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands.ProductCategories
{
    public class CreateProductCategoryCommand : Request<ProductCategoryDto>
    {
        public string Name { get; }

        public CreateProductCategoryCommand(string name) => Name = name;
    }
}