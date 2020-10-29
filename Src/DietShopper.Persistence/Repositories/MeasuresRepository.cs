using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Products.Repositories;
using DietShopper.Domain.Entities;

namespace DietShopper.Persistence.Repositories
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly AppDbContext _context;

        public MeasuresRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IReadOnlyCollection<Measure>> GetActiveMeasures()
        {
            return _context.Measures
                .Where(x => x.IsActive)
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync();
        }
    }
}