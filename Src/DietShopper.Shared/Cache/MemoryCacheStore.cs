using System;
using System.Threading.Tasks;
using DietShopper.Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace DietShopper.Shared.Cache
{
    public class MemoryCacheStore : ICacheStore
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheStore(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<TItem> GetOrCreateAsync<TItem>(string key, Func<Task<TItem>> factory,
            CacheStoreOptions options = default)
        {
            return _memoryCache.GetOrCreateAsync(key, entry =>
            {
                options ??= CacheStoreOptions.CreateDefault();

                return factory();
            });
        }

        public TItem GetOrCreate<TItem>(string key, Func<TItem> factory, CacheStoreOptions options = default)
        {
            return _memoryCache.GetOrCreate(key, entry =>
            {
                options ??= CacheStoreOptions.CreateDefault();

                return factory();
            });
        }
    }
}