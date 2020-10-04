using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence.Utils
{
    public interface IDbInitializer
    {
        Task ExecuteAsync();
    }
    
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}