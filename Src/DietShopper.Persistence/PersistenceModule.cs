using DietShopper.Application.Repositories;
using DietShopper.Persistence.Behaviors;
using DietShopper.Persistence.Repositories;
using DietShopper.Persistence.Utils;
using MediatR;
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
                .AddTransient<IDbInitializer, DbInitializer>()
                .AddTransient<IPageableRequestHelper, PageableRequestHelper>()
                .AddTransient<IUsersRepository, UsersRepository>()
                .AddTransient<IProductCategoriesRepository, ProductCategoryRepository>()
                .AddTransient<IMeasuresRepository, MeasuresRepository>()
                .AddTransient<IProductsRepository, ProductsRepository>()
                .AddTransient<IProductMeasuresRepository, ProductMeasuresRepository>()
                .AddTransient<IRecipesRepository, RecipesRepository>()
                ;

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

        public static IServiceCollection AddPersistenceModuleBehaviors(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehavior<,>))
                .AddScoped<ITransactionScopeManager, TransactionScopeManager>();

            return services;
        }
    }
}