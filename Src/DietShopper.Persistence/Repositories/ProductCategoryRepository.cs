using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Products.Repositories;
using DietShopper.Domain.Entities;

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
            return _context.ProductCategories.Where(x => x.IsActive).ToReadOnlyCollectionAsync();
        }

        public Task Save(ProductCategory productCategory)
        {
            _context.Attach(productCategory);
            return _context.SaveChangesAsync();
        }
    }
}