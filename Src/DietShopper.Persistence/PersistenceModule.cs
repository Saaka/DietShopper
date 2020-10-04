using DietShopper.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.Persistence
{
    public static class PersistenceModule
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection services)
        {
            services
                .AddTransient<IDbInitializer, DbInitializer>();

            return services;
        }
        
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.AppConnectionString);
            services.AddDbContext<AppDbContext>((opt) =>
                    opt.UseSqlServer(
                        connectionString,
                        cb => { cb.MigrationsHistoryTable(Constants.DefaultMigrationsTable); }),
                ServiceLifetime.Scoped);

            return services;
        }
    }
}