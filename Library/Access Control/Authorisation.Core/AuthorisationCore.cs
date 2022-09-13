using Authorisation.Core.Interfaces;
using Authorisation.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authorisation.Core
{
    public static class AuthorisationCore
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAuthorisationService, AuthorisationService>();
        }
    }
}
