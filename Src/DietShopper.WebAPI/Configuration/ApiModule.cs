using DietShopper.WebAPI.Behaviors;
using DietShopper.WebAPI.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.WebAPI.Configuration
{
    public static class ApiModule
    {
        public static IServiceCollection AddApiModule(this IServiceCollection services)
        {
            services
                .AddTransient<IContextDataProvider, ContextDataProvider>();

            return services;
        }

        public static IServiceCollection AddAuthorizationBehavior(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            return services;
        }
    }
}