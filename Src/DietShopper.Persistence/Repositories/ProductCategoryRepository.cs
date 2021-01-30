using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoriesRepository
    {
        private readonly AppDbContext _context;
        private readonly ICacheStore _cacheStore;

        public ProductCategoryRepository(AppDbContext context, ICacheStore cacheStore)
        {
            _context = context;
            _cacheStore = cacheStore;
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

        public Task<int> GetCategoryId(Guid productCategoryGuid)
        {
            return _cacheStore.GetOrCreateAsync($"{Constants.CacheKeys.ProductCategoryIdCacheKey}{productCategoryGuid}", () 
                => _context.ProductCategories.Where(x=>x.ProductCategoryGuid == productCategoryGuid).Select(x=> x.ProductCategoryId).FirstOrDefaultAsync());
        }
    }
}