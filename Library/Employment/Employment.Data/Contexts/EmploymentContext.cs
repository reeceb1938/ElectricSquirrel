using Employment.Data.Models;
using Employment.Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Employment.Data.Contexts
{
    public class EmploymentContext : DbContext
    {
        public EmploymentContext(DbContextOptions<EmploymentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployerConfiguiration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new ShiftConfiguration());
        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
