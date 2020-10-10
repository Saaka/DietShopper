using DietShopper.Shared.Behaviors;
using DietShopper.Shared.Http;
using MediatR;
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

        public static IServiceCollection AddSharedModuleBehaviors(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLogger<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            return services;
        }
    }
}