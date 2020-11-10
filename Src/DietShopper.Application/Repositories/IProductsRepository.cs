using System;
using System.Threading.Tasks;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IProductsRepository
    {
        Task Save(Product product);
        Task<bool> IsNameTaken(string name);
        Task<bool> IsNameTaken(Guid productGuid, string name);
        Task<bool> IsShortNameTaken(string shortName);
        Task<bool> IsShortNameTaken(Guid productGuid, string shortName);
        Task<CompleteProductDto> GetCompleteProduct(Guid productGuid);
        Task<PagedList<SimpleProductDto>> GetSimpleProductsList(GetSimpleProductsQueryModel query);
    }
}