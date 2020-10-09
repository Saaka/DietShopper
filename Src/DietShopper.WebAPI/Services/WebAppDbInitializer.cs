using System;
using System.Threading.Tasks;
using DietShopper.Persistence.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DietShopper.WebAPI.Services
{
    public class WebAppDbInitializer
    {
        public static async Task InitializeAsync(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<WebAppDbInitializer>>();
                try
                {
                    logger.LogInformation("Initializing database");

                    var initializer = services.GetRequiredService<IDbInitializer>();
                    await initializer.ExecuteAsync();

                    logger.LogInformation("Database initialization successful");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                    throw;
                }
            }
        }
    }
}