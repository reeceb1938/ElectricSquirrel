using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Employment.Data.Contexts.Factories
{
    public class DesignTimeEmploymentContextFactory : IDesignTimeDbContextFactory<EmploymentContext>
    {
        public EmploymentContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + "/../../../ElectricSquirrel.API/")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EmploymentContext>();
            builder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new EmploymentContext(builder.Options);
        }
    }
}
