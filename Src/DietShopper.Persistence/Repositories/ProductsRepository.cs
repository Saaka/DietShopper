using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Domain.Entities;

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
    }
}