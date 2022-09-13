using Authentication.Core.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data.Contexts
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserContext(DbContextOptions<ApplicationUserContext> options) : base(options)
        {
        }
    }
}
