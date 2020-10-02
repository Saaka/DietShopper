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
                .AddMvcWithFilters()
                .AddJwtTokenBearerAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                application.UseDeveloperExceptionPage();
            
            if (env.IsProduction())
                application
                    .UseHsts()
                    .UseHttpsRedirection();

            application
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(e => { e.MapControllers(); });
        }
    }
}