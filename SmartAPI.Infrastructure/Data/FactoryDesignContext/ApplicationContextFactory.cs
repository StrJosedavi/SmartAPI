using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartAPI.Infrastructure.Data.FactoryDesignContext
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var conectionString = "Host=localhost;Port=5432;Database=SmartAPI;Username=Davi;Password=123";

            optionsBuilder.UseNpgsql(conectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
