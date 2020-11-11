using System.Linq;
using System.Threading.Tasks;
using DietShopper.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Utils
{
    public interface IPageableRequestHelper
    {
        Task<PagedList<T>> GetPagedListAsync<T>(IQueryable<T> query, IPageableRequest request);
    }

    public class PageableRequestHelper : IPageableRequestHelper
    {
        public async Task<PagedList<T>> GetPagedListAsync<T>(IQueryable<T> query, IPageableRequest request)
        {
            var totalItemsCount = await query.CountAsync();
            var result = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            
            return new PagedList<T>(result, request.PageNumber,request.PageSize, totalItemsCount);
        }
    }
}