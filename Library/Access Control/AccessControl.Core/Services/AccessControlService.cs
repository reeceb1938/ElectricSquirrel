using AccessControl.Core.Commands;
using AccessControl.Core.Interfaces;
using AccessControl.Core.Responses;
using Authentication.Core.Interfaces;
using Authorisation.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AccessControl.Core.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorisationService _authorisationService;

        public AccessControlService(IHttpContextAccessor httpContextAccessor, IAuthenticationService authenticationService, IAuthorisationService authorisationService)
        {
            _authenticationService = authenticationService;
            _authorisationService = authorisationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> LoginAsync(Login command)
        {
            var authenticateCommand = new Authentication.Core.Commands.Login
            {
                EmailAddress = command.Username,
                Password = command.Password
            };

            var authenticateResponse = await _authenticationService.LoginAsync(authenticateCommand);

            if (authenticateResponse.Succeeded)
            {
                return new LoginResponse()
                {
                    IsAuthenticated = true,
                    UserName = authenticateResponse.UserName,
                    Roles = authenticateResponse.Roles,
                    Token = authenticateResponse.Token
                };
            }

            return new LoginResponse();
        }

        public void Logout(object command)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponse> RegisterAsync(Register command)
        {
            var authCommand = new Authentication.Core.Commands.Register
            {
                EmailAddress = command.EmailAddress,
                Password = command.Password,
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            var authResponse = await _authenticationService.RegisterAsync(authCommand);

            // QUESTION: Should successful register log you in? Probably

            return new RegisterResponse
            {
                IsSuccess = authResponse.IsSuccess,
                Message = authResponse.Message
            };
        }

        public async Task<bool> AddUserToRole(AddUserToRole command)
        {
            throw new NotImplementedException();
        }
    }
}
