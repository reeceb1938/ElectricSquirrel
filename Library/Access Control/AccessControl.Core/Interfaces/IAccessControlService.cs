using AccessControl.Core.Commands;
using AccessControl.Core.Responses;

namespace AccessControl.Core.Interfaces
{
    public interface IAccessControlService
    {
        Task<LoginResponse> LoginAsync(Login command);

        void Logout(object command);

        Task<RegisterResponse> RegisterAsync(Register command);
    }
}
