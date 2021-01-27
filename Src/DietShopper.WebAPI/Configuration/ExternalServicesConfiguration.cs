using System.Reflection;
using AutoMapper;
using DietShopper.Application;
using DietShopper.Integration;
using DietShopper.Persistence;
using DietShopper.Shared;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.WebAPI.Configuration
{
    public static class ExternalServicesConfiguration
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services
                .AddAutoMapper(new Assembly[]
                {
                    typeof(ApplicationModule).Assembly,
                    typeof(IntegrationModule).Assembly,
                    typeof(PersistenceModule).Assembly,
                    typeof(Startup).Assembly
                })
                .AddMemoryCache()
                .AddMediatRBehaviors()
                .AddMediatR(typeof(ApplicationModule).Assembly)
                .AddMediatR(typeof(SharedInfrastructureModule).Assembly);

            return services;
        }
        
        private static IServiceCollection AddMediatRBehaviors(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>))

                .AddSharedLoggerBehavior()
                .AddAuthorizationBehavior()
                .AddRequestAuthorizationValidationBehavior()
                .AddPersistenceModuleBehaviors()
                .AddCommandValidationBehavior();            

            return services;
        }
    }
}