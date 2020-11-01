using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class CreateProductCategoryCommand : Request<ProductCategoryDto>
    {
        public string Name { get; }

        public CreateProductCategoryCommand(string name) => Name = name;
    }
}