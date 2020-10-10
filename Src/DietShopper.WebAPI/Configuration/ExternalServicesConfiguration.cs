using System.Reflection;
using AutoMapper;
using DietShopper.Application;
using DietShopper.Integration;
using DietShopper.Persistence;
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
                    typeof(IntegrationModule).Assembly
                })
                .AddMemoryCache()
                .AddMediatRBehaviors()
                .AddMediatR(typeof(ApplicationModule).Assembly);

            return services;
        }
        
        private static IServiceCollection AddMediatRBehaviors(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>))

                .AddPersistenceModuleBehaviors();            
            return services;
        }
    }
}