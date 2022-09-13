using Authentication.Core.Commands;
using Authentication.Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(Login command);

        void Logout();

        Task<RegisterResponse> RegisterAsync(Register command);
    }
}
