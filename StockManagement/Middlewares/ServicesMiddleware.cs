using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace StockManagement.Middlewares
{
    public static class ServicesMiddleware
    {
        public static void ConfigureAuthenticationMiddleware(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
        public static void ConfigureCookieMiddleware(this IApplicationBuilder app)
        {
            var cookiePolicyOptions = new CookiePolicyOptions{
                MinimumSameSitePolicy = SameSiteMode.Strict
            };
            
            app.UseCookiePolicy(cookiePolicyOptions);
        }
    }
}