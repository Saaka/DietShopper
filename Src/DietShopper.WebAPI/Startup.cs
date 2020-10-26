using DietShopper.Integration;
using DietShopper.Persistence;
using DietShopper.Shared;
using DietShopper.WebAPI.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DietShopper.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAppDbContext(Configuration)
                .AddPersistenceModule()
                .AddSharedInfrastructureModule()
                .AddApiModule()
                .AddIntegrationsModule()
                .AddExternalServices()
                .AddMvcWithFilters(Configuration)
                .AddJwtTokenBearerAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
            if (env.IsProduction())
                application
                    .UseHsts()
                    .UseHttpsRedirection();

            application
                .UseRouting()
                .UseCors()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(e => { e.MapControllers(); });
        }
    }
}