using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class CreateProductCategoryCommand : Request<ProductCategoryDto>, IRequestWithAdminAuthorization
    {
        public string Name { get; set; }
    }
}