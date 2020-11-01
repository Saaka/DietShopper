using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IProductCategoriesRepository
    {
        Task<IReadOnlyCollection<ProductCategory>> GetActiveProductCategories();
        Task Save(ProductCategory productCategory);
        Task<ProductCategory> GetProductCategory(Guid productCategoryGuid);
        Task<bool> IsNameTaken(string name);
        Task<bool> IsNameTaken(Guid productCategoryGuid, string name);
    }
}