using DietShopper.Application.Services;
using DietShopper.Shared.Behaviors;
using DietShopper.Shared.Http;
using DietShopper.Shared.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.Shared
{
    public static class SharedInfrastructureModule
    {
        public static IServiceCollection AddSharedInfrastructureModule(this IServiceCollection services)
        {
            services
                .AddTransient<IRestsharpClientFactory, RestsharpClientFactory>()
                .AddTransient<IGuid, GuidProvider>();

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