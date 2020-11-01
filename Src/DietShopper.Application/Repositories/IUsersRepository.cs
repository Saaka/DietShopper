using System;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetByGuid(Guid userGuid);
        Task<int> GetUserIdByGuid(Guid userGuid);
        Task Upsert(User user);
    }
}