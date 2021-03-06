using System.Text;
using DietShopper.Application;
using DietShopper.WebAPI.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DietShopper.WebAPI.Configuration
{
    public static class MvcConfiguration
    {
        public static IServiceCollection AddMvcWithFilters(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddCors(opt =>
                {
                    opt.AddDefaultPolicy(
                        builder =>
                        {
                            builder
                                .AllowCredentials()
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .WithOrigins(configuration[ApplicationSettings.AuthAllowedOrigin]);
                        });
                })
                .AddControllers(options =>
                {
                    options.Filters.Add<CustomExceptionFilterAttribute>();
                })
                .AddFluentValidation(v =>
                {
                    v.RegisterValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
                    v.LocalizationEnabled = false;
                    v.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; })
                .AddHttpContextAccessor();

            return services;
        }
        
        public static IServiceCollection AddJwtTokenBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration[ApplicationSettings.AuthSecretProperty];
            var key = Encoding.ASCII.GetBytes(secret);
        
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                
                        ValidateIssuer = true,
                        ValidIssuer = configuration[ApplicationSettings.AuthIssuerProperty],
                
                        ValidateAudience = false
                    };
                })
                ;
        
            return services;
        }
    }
}