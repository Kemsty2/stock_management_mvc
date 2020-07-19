using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using StockManagement.Services.Refit;
using System;
using StockManagement.Services;
using StockManagement.Services.Impl;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using StockManagement.Security;

namespace StockManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAuthentification(this IServiceCollection services)
        {
            // https://www.c-sharpcorner.com/article/policy-based-role-based-authorization-in-asp-net-core/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/Home/Login";
                    config.LogoutPath = "/Home/Logout";
                    config.AccessDeniedPath = "/Home/AccessDenied";
                }
            );

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder => {
                    policyBuilder.UserRequirementCustomClaim(ClaimTypes.Name);                                    
                });
            });

            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();            
        }

        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHistoriqueService, HistoriqueService>();
            services.AddScoped<ITypeProduitService, TypeProduitService>();
            services.AddScoped<IActiviteService, ActiviteService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Converters = { new StringEnumConverter() }
                    })
            };

            services.AddRefitClient<IStockApi>(settings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["StockApiUri"]));
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}