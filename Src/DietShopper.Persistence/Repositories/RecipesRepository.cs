using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Domain.Entities;

namespace DietShopper.Persistence.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly AppDbContext _context;

        public RecipesRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Task Save(Recipe recipe)
        {
            _context.Attach(recipe);
            return _context.SaveChangesAsync();
        }
    }
}