using Employment.Core.Interfaces;
using Employment.Data.Contexts;
using Employment.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.Data
{
    public static class EmploymentData
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IEmploymentRepository, EmploymentRepository>();
            services.AddDbContext<EmploymentContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }
    }
}
