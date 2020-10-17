using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Products.Repositories
{
    public interface IProductCategoriesRepository
    {
        Task<IReadOnlyCollection<ProductCategory>> GetActiveProductCategories();
        Task Save(ProductCategory productCategory);
    }
}