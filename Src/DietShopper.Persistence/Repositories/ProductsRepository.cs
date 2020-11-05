using System;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Save(Product product)
        {
            _context.Attach(product);
            return _context.SaveChangesAsync();
        }

        public Task<bool> IsNameTaken(string name) => IsNameTaken(Guid.Empty, name);
        public Task<bool> IsNameTaken(Guid productGuid, string name) => _context.Products.AnyAsync(x => x.ProductGuid != productGuid && x.Name == name && x.IsActive);
        public Task<bool> IsShortNameTaken(string name) => IsShortNameTaken(Guid.Empty, name);
        public Task<bool> IsShortNameTaken(Guid productGuid, string shortName) => _context.Products.AnyAsync(x => x.ProductGuid != productGuid && x.ShortName == shortName && x.IsActive);

        public Task<CompleteProductDto> GetCompleteProduct(Guid productGuid)
        {
            var query = from product in _context.Products
                join productCategory in _context.ProductCategories on product.ProductCategoryId equals productCategory.ProductCategoryId
                join measure in _context.Measures on product.DefaultMeasureId equals measure.MeasureId
                join nutrients in _context.ProductNutrients on product.ProductId equals nutrients.ProductId
                where product.ProductGuid == productGuid
                select new CompleteProductDto
                {
                    ProductGuid = product.ProductGuid,
                    Name = product.Name,
                    ShortName = product.ShortName,
                    Description = product.Description,
                    ProductCategoryGuid = productCategory.ProductCategoryGuid,
                    DefaultMeasureGuid = measure.MeasureGuid,
                    Calories = nutrients.Calories,
                    Carbohydrates = nutrients.Carbohydrates,
                    Proteins = nutrients.Proteins,
                    Fat = nutrients.Fat,
                    SaturatedFat = nutrients.SaturatedFat,
                    IsActive = product.IsActive,
                    
                };

            return query.FirstOrDefaultAsync();
        }
    }
}