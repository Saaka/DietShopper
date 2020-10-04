using System.Threading.Tasks;
using DietShopper.WebAPI.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DietShopper.WebAPI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await WebAppDbInitializer.InitializeAsync(host);
            await host.RunAsync();
        }

        private static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}