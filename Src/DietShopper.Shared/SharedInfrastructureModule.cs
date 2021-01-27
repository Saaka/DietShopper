using DietShopper.Application.Services;
using DietShopper.Shared.Behaviors;
using DietShopper.Shared.Cache;
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
                .AddTransient<IGuid, GuidProvider>()
                .AddTransient<ICacheStore, MemoryCacheStore>()
                .AddTransient<IRequestAuthorizationValidator, RequestAuthorizationValidator>();

            return services;
        }

        public static IServiceCollection AddSharedLoggerBehavior(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLogger<,>));
            return services;
        }

        public static IServiceCollection AddCommandValidationBehavior(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            return services;
        }
    }
}