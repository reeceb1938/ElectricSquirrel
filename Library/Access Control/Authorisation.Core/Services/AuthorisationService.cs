using Authentication.Core.DTOs;
using Authentication.Core.Settings;
using Authorisation.Core.Commands;
using Authorisation.Core.Interfaces;
using Authorisation.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authorisation.Core.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthorisationService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateRoleResponse> CreateRoleAsync(string name)
        {
            var newRole = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(newRole);
            return new CreateRoleResponse()
            {
                Succeeded = result.Succeeded,
                RoleName = name
            };
        }

        public async Task<AssignRoleToUserResponse> AssignRoleToUserAsync(AssignRoleToUser command)
        {
            var user = await _userManager.FindByEmailAsync(command.EmailAddress);
            if (user is not null)
            {
                var result = await _userManager.AddToRoleAsync(user, command.RoleName);
            }

            return new AssignRoleToUserResponse
            {
                Status = AssignRoleToUserResponse.StatusCode.UserDoesNotExist
            };
        }
    }
}
