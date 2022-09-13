using Authentication.Core.Interfaces;
using Authentication.Data.Contexts;

namespace Authentication.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationUserContext _applicationUserContext;

        public AuthenticationRepository(ApplicationUserContext applicationUserContext)
        {
            _applicationUserContext = applicationUserContext;
        }
    }
}
