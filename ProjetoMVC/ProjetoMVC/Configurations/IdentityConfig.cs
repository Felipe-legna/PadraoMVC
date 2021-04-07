using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoMVC.Data;
using ProjetoMVC.Data.Context;



namespace ProjetoMVC.Site.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ProjetoMVCContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            

            services.AddIdentityCore< IdentityUser >()
                //.AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
