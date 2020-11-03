using System;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IProductsRepository
    {
        Task Save(Product product);
        Task<bool> IsNameTaken(string name);
        Task<bool> IsNameTaken(Guid productGuid, string name);
    }
}