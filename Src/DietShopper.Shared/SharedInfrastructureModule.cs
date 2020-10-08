using DietShopper.Shared.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.Shared
{
    public static class SharedInfrastructureModule
    {
        public static IServiceCollection AddSharedInfrastructureModule(this IServiceCollection services)
        {
            services
                .AddTransient<IRestsharpClientFactory, RestsharpClientFactory>();

            return services;
        }
    }
}