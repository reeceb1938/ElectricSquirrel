using Authentication.Core.Commands;
using Authentication.Core.DTOs;
using Authentication.Core.Interfaces;
using Authentication.Core.Responses;
using Authentication.Core.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        private readonly SymmetricSecurityKey _symmetricSigningKey;
        private readonly SigningCredentials _signingCredentials;

        public AuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;

            _symmetricSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            _signingCredentials = new SigningCredentials(_symmetricSigningKey, SecurityAlgorithms.HmacSha256);
        }

        public async Task<LoginResponse> LoginAsync(Login command)
        {
            var result = new LoginResponse();

            var user = await _userManager.FindByEmailAsync(command.EmailAddress);
            if (user is null)
            {
                result.Status = LoginResponse.StatusCode.AccountDoesNotExist;
                return result;
            }

            if (await _userManager.CheckPasswordAsync(user, command.Password))
            {
                JwtSecurityToken token = await CreateJwtTokenAsync(user);
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                result.Status = LoginResponse.StatusCode.Success;
                result.Token = new JwtSecurityTokenHandler().WriteToken(token);
                result.EmailAddress = user.Email;
                result.UserName = user.UserName;
                result.Roles = rolesList.ToList();

                return result;
            }

            result.Status = LoginResponse.StatusCode.InvalidCredentails;
            return result;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponse> RegisterAsync(Register command)
        {
            var user = new ApplicationUser
            {
                UserName = command.EmailAddress,
                Email = command.EmailAddress,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            var existingUser = await _userManager.FindByEmailAsync(command.EmailAddress);

            if (existingUser is null)
            {
                var result = await _userManager.CreateAsync(user, command.Password);

                if (result.Succeeded)
                {
                    // TODO: Add to default role
                    //await _userManager.AddToRoleAsync(user)
                    return new RegisterResponse
                    {
                        IsSuccess = true
                    };
                }
                else
                {
                    return new RegisterResponse
                    {
                        Message = $"Failed to create user with email {user.Email}"
                    };
                }
            }
            else
            {
                return new RegisterResponse
                {
                    Message = $"{user.Email} is already registered"
                };
            }
        }

        private async Task<JwtSecurityToken> CreateJwtTokenAsync(ApplicationUser user)
        {
            var claims = await GetValidUserClaims(user);

            return new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: _signingCredentials
            );
        }

        private async Task<List<Claim>> GetValidUserClaims(ApplicationUser user)
        {
            var _options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));

                var role = await _roleManager.FindByNameAsync(userRole);
                if (role is not null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }
    }
}
