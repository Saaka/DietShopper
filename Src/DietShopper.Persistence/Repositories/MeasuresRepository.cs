using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly AppDbContext _context;
        private readonly ICacheStore _cacheStore;

        public MeasuresRepository(AppDbContext context,
            ICacheStore cacheStore)
        {
            _context = context;
            _cacheStore = cacheStore;
        }

        public Task<IReadOnlyCollection<Measure>> GetActiveMeasures()
        {
            return _context.Measures
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.IsBaseline).ThenByDescending(x => x.IsWeight).ThenBy(x => x.Name)
                .ToReadOnlyCollectionAsync();
        }

        public Task Save(Measure measure)
        {
            _context.Attach(measure);
            return _context.SaveChangesAsync();
        }

        public Task<Measure> GetMeasure(Guid measureGuid)
        {
            return _context.Measures.FirstOrDefaultAsync(x => x.MeasureGuid == measureGuid);
        }

        public Task<bool> IsNameTaken(string name) => IsNameTaken(Guid.Empty, name);

        public Task<bool> IsNameTaken(Guid measureGuid, string name)
        {
            return _context.Measures
                .AnyAsync(x =>
                    x.MeasureGuid != measureGuid
                    && x.Name == name
                    && x.IsActive);
        }

        public Task<bool> IsSymbolTaken(string symbol) => IsSymbolTaken(Guid.Empty, symbol);

        public Task<bool> IsSymbolTaken(Guid measureGuid, string symbol)
        {
            return _context.Measures
                .AnyAsync(x =>
                    x.MeasureGuid != measureGuid
                    && x.Symbol == symbol
                    && x.IsActive);
        }

        public Task<int> GetBaselineMeasureId()
        {
            return _cacheStore.GetOrCreateAsync(Constants.CacheKeys.BaselineMeasureIdCacheKey, () => _context.Measures.Where(x => x.IsBaseline).Select(x => x.MeasureId).FirstOrDefaultAsync());
        }

        public Task<int> GetMeasureId(Guid measureGuid)
        {
            return _cacheStore.GetOrCreateAsync($"{Constants.CacheKeys.MeasureIdCacheKey}{measureGuid}", ()
                => _context.Measures.Where(x => x.MeasureGuid == measureGuid).Select(x => x.MeasureId).FirstOrDefaultAsync());
        }
    }
}