using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DietShopper.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var connectionString = GetConnectionString(environment);
            
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(connectionString,
                opt => opt.MigrationsHistoryTable(Constants.DefaultMigrationsTable)
            );

            return new DbContext(optionsBuilder.Options);
        }

        private string GetConnectionString(string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(Constants.AppConnectionString);
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("ConnectionString is null or empty");

            return connectionString;
        }
    }
}