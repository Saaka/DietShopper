using DietShopper.Application.Auth.Services;
using DietShopper.Integration.IdentityIssuer;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.Integration
{
    public static class IntegrationModule
    {
        public static IServiceCollection AddIntegrationsModule(this IServiceCollection services)
        {
            services
                .AddTransient<IGoogleAuthorizationClient, IdentityIssuerClient>()
                .AddTransient<IIdentityIssuerConfiguration, IdentityIssuerConfiguration>()
                ;

            return services;
        }
    }
}