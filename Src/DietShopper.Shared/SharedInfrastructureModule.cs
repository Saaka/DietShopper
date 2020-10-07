using DietShopper.Shared.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.Shared
{
    public static class SharedInfrastructureModule
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IRestsharpClientFactory, RestsharpClientFactory>();

            return services;
        }
    }
}