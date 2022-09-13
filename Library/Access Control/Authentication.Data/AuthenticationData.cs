using Authentication.Core.DTOs;
using Authentication.Core.Interfaces;
using Authentication.Data.Contexts;
using Authentication.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Data
{
    public static class AuthenticationData
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            // Configure user management service
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationUserContext>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationUserContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }
    }
}
