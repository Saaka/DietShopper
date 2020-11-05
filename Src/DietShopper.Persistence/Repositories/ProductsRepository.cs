using System;
using System.Threading.Tasks;
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
    }
}