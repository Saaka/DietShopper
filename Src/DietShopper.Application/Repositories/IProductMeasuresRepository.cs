using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Repositories.Models;

namespace DietShopper.Application.Repositories
{
    public interface IProductMeasuresRepository
    {
        Task<IReadOnlyCollection<ProductMeasureBaseDto>> GetProductMeasureBaseByGuids(IEnumerable<Guid> productMeasureGuids);
    }
}