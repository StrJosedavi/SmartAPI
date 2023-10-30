using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartAPI.Infrastructure.Data.FactoryDesignContext {
    internal class IdentityContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext> {
        public ApplicationIdentityDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            var conectionString = "Host=localhost;Port=5432;Database=SmartAPI;Username=Davi;Password=123";

            optionsBuilder.UseNpgsql(conectionString);

            return new ApplicationIdentityDbContext(optionsBuilder.Options);
        }
    }
}
