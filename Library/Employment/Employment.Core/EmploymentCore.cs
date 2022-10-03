using Employment.Core.Interfaces;
using Employment.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.Core
{
    public static class EmploymentCore
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IEmploymentService, EmploymentService>();
        }
    }
}
