using System;
using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetByGuid(Guid userGuid);
        Task Upsert(User user);
    }
}