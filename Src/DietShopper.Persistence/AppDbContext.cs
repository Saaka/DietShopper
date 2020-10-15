using System.Threading.Tasks;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(Constants.DefaultSchema);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
                x => x.Namespace == typeof(Configurations.UserConfiguration).Namespace);
        }
    }
}