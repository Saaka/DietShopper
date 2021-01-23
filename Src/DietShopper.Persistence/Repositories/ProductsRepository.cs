using System;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Domain.Entities;
using DietShopper.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;
        private readonly IPageableRequestHelper _pageableRequestHelper;

        public ProductsRepository(AppDbContext context,
            IPageableRequestHelper pageableRequestHelper)
        {
            _context = context;
            _pageableRequestHelper = pageableRequestHelper;
        }

        public Task Save(Product product)
        {
            _context.Attach(product);
            return _context.SaveChangesAsync();
        }

        public Task<Product> GetProductEntity(Guid productGuid) => _context
            .Products
            .Include(x=> x.ProductNutrients)
            .Include(x=> x.ProductCategory)
            .Include(x => x.ProductMeasures)
            .ThenInclude(x => x.Measure)
            .FirstOrDefaultAsync(x => x.ProductGuid == productGuid);

        public Task<bool> IsNameTaken(string name) => IsNameTaken(Guid.Empty, name);
        public Task<bool> IsNameTaken(Guid productGuid, string name) => _context.Products.AnyAsync(x => x.ProductGuid != productGuid && x.Name == name && x.IsActive);
        public Task<bool> IsShortNameTaken(string name) => IsShortNameTaken(Guid.Empty, name);
        public Task<bool> IsShortNameTaken(Guid productGuid, string shortName) => _context.Products.AnyAsync(x => x.ProductGuid != productGuid && x.ShortName == shortName && x.IsActive);

        public Task<CompleteProductDto> GetCompleteProduct(Guid productGuid)
        {
            var query = from product in _context.Products
                join productCategory in _context.ProductCategories on product.ProductCategoryId equals productCategory.ProductCategoryId
                join defaultMeasure in _context.Measures on product.DefaultMeasureId equals defaultMeasure.MeasureId
                join nutrients in _context.ProductNutrients on product.ProductId equals nutrients.ProductId
                where product.ProductGuid == productGuid
                select new CompleteProductDto
                {
                    ProductGuid = product.ProductGuid,
                    Name = product.Name,
                    ShortName = product.ShortName,
                    Description = product.Description,
                    ProductCategoryGuid = productCategory.ProductCategoryGuid,
                    DefaultMeasureGuid = defaultMeasure.MeasureGuid,
                    Calories = nutrients.Calories,
                    Carbohydrates = nutrients.Carbohydrates,
                    Proteins = nutrients.Proteins,
                    Fat = nutrients.Fat,
                    SaturatedFat = nutrients.SaturatedFat,
                    IsActive = product.IsActive,
                    ProductMeasures = (from measures in _context.Measures
                        join productMeasure in _context.ProductMeasures on measures.MeasureId equals productMeasure.MeasureId
                        where productMeasure.ProductId == product.ProductId
                        select new ProductMeasureDto
                        {
                            ProductMeasureGuid = productMeasure.ProductMeasureGuid,
                            MeasureGuid = measures.MeasureGuid,
                            ValueInGrams = productMeasure.ValueInGrams
                        }).ToList()
                };

            return query.FirstOrDefaultAsync();
        }

        public Task<PagedList<SimpleProductDto>> GetSimpleProductsList(GetSimpleProductsQuery model)
        {
            var query = from product in _context.Products
                join productCategory in _context.ProductCategories on product.ProductCategoryId equals productCategory.ProductCategoryId
                select new SimpleProductDto
                {
                    Name = product.Name,
                    ProductGuid = product.ProductGuid,
                    ProductCategoryGuid = productCategory.ProductCategoryGuid,
                    ProductCategoryName = productCategory.Name
                };

            return _pageableRequestHelper.GetPagedListAsync(query, model);
        }
    }
}