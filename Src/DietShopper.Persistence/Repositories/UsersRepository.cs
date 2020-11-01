using System;
using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<User> GetByGuid(Guid userGuid)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.UserGuid == userGuid);
        }

        public Task<int> GetUserIdByGuid(Guid userGuid)
        {
            return _context.Users
                .Where(x => x.UserGuid == userGuid)
                .Select(x => x.UserId)
                .FirstOrDefaultAsync();
        }

        public Task Upsert(User user)
        {
            _context.Attach(user);
            return _context.SaveChangesAsync();
        }
    }
}