using DietShopper.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.WebAPI.Configuration
{
    public static class MvcConfiguration
    {
        public static IServiceCollection AddMvcWithFilters(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add<CustomExceptionFilterAttribute>();
                });

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; })
                .AddHttpContextAccessor();

            return services;
        }
    }
}