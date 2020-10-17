using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence
{
    public static class QueryExtensions
    {
        public static Task<IReadOnlyCollection<T>> ToReadOnlyCollectionAsync<T>(this IQueryable<T> query)
        {
            return query.ToListAsync().ContinueWith(x => x.Result as IReadOnlyCollection<T>);
        }
    }
}