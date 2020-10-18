using System;
using System.Threading.Tasks;

namespace DietShopper.Application.Services
{
    public interface ICacheStore
    {
        Task<TItem> GetOrCreateAsync<TItem>(string key, Func<Task<TItem>> factory, CacheStoreOptions options = default);
        TItem GetOrCreate<TItem>(string key, Func<TItem> factory, CacheStoreOptions options = default);
    }

    public class CacheStoreOptions
    {
        public const int DefaultSlidingExpirationInMinutes = 5;
        public const int DefaultAbsoluteExpirationInMinutes = 60;
        
        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed.
        /// </summary>
        public TimeSpan? SlidingExpiration { get; set; } 
        
        /// <summary>
        /// Gets or sets an absolute expiration date for the cache entry.
        /// </summary>
        DateTimeOffset? AbsoluteExpiration { get; set; }

        public static CacheStoreOptions CreateDefault() => new CacheStoreOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(DefaultSlidingExpirationInMinutes),
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(DefaultAbsoluteExpirationInMinutes)
        };
    }
}