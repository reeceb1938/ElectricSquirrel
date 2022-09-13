using AccessControl.Core.Interfaces;
using AccessControl.Core.Services;
using Authentication.Core;
using Authentication.Data;
using Authorisation.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControl.Core
{
    public static class AccessControlCore
    {
        public static void Setup(IServiceCollection services, IConfiguration config)
        {
            // NOTE: Data before Core here because JWT setup requires Identity to be set
            AuthenticationData.Setup(services, config);
            AuthenticationCore.Setup(services, config);

            AuthorisationCore.Setup(services, config);

            services.AddScoped<IAccessControlService, AccessControlService>();
        }
    }
}
