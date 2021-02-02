using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Commands.Products.Models;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IProductsRepository
    {
        Task Save(Product product);
        Task<Product> GetProductEntity(Guid productGuid);
        Task<bool> IsNameTaken(string name);
        Task<bool> IsNameTaken(Guid productGuid, string name);
        Task<bool> IsShortNameTaken(string shortName);
        Task<bool> IsShortNameTaken(Guid productGuid, string shortName);
        Task<CompleteProductQueryResultDto> GetCompleteProduct(Guid productGuid);
        Task<PagedList<SimpleProductQueryResultDto>> GetSimpleProductsList(GetSimpleProductsQueryDto queryDto);
        Task<IReadOnlyCollection<ProductGuidDto>> GetProductIdsByGuids(IEnumerable<Guid> productGuids);
    }
}