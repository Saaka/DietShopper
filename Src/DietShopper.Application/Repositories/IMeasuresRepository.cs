using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IMeasuresRepository
    {
        Task<IReadOnlyCollection<Measure>> GetActiveMeasures();
        Task Save(Measure measure);
        Task<Measure> GetMeasure(Guid measureGuid);
        Task<bool> IsNameTaken(string name);
        Task<bool> IsNameTaken(Guid measureGuid, string name);
        Task<bool> IsSymbolTaken(string symbol);
        Task<bool> IsSymbolTaken(Guid measureGuid, string symbol);
    }
}