using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietShopper.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<ProductMeasure> ProductMeasures { get; set; }
        public DbSet<ProductNutrients> ProductNutrients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(Constants.DefaultSchema);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
                x => x.Namespace == typeof(Configurations.UserConfiguration).Namespace);
        }
    }
}