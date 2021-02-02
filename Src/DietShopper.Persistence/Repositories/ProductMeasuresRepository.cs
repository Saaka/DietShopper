using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Application.Repositories.Models;

namespace DietShopper.Persistence.Repositories
{
    public class ProductMeasuresRepository : IProductMeasuresRepository
    {
        private readonly AppDbContext _context;

        public ProductMeasuresRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IReadOnlyCollection<ProductMeasureBaseDto>> GetProductMeasureBaseByGuids(IEnumerable<Guid> productMeasureGuids)
        {
            var query = from pm in _context.ProductMeasures
                where productMeasureGuids.Contains(pm.ProductMeasureGuid)
                select new ProductMeasureBaseDto
                {
                    ProductMeasureId = pm.ProductMeasureId,
                    ProductMeasureGuid = pm.ProductMeasureGuid,
                    ValueInGrams = pm.ValueInGrams,
                };

            return query.ToReadOnlyCollectionAsync();
        }
    }
}