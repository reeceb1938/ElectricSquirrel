using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Authentication.Data.Contexts.Factories
{
    public class DesignTimeUserContextFactory : IDesignTimeDbContextFactory<ApplicationUserContext>
    {
        public ApplicationUserContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + "/../../../ElectricSquirrel.API/")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationUserContext>();
            builder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new ApplicationUserContext(builder.Options);
        }
    }
}
