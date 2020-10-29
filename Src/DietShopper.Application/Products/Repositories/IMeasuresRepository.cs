using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Products.Repositories
{
    public interface IMeasuresRepository
    {
        Task<IReadOnlyCollection<Measure>> GetActiveMeasures();
    }
}