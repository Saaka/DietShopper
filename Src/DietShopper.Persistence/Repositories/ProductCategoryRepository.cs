using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Products.Repositories;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IReadOnlyCollection<ProductCategory>> GetActiveProductCategories()
        {
            return _context.ProductCategories
                .Where(x => x.IsActive)
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync();
        }

        public Task Save(ProductCategory productCategory)
        {
            _context.Attach(productCategory);
            return _context.SaveChangesAsync();
        }

        public Task<ProductCategory> GetProductCategory(Guid productCategoryGuid)
        {
            return _context.ProductCategories.FirstOrDefaultAsync(x => x.ProductCategoryGuid == productCategoryGuid);
        }

        public Task<bool> IsNameTaken(string name)
        {
            return _context.ProductCategories.AnyAsync(x => x.Name == name && x.IsActive);
        }

        public Task<bool> IsNameTaken(Guid productCategoryGuid, string name)
        {
            return _context.ProductCategories
                .AnyAsync(x =>
                    x.ProductCategoryGuid != productCategoryGuid
                    && x.Name == name
                    && x.IsActive);
        }
    }
}