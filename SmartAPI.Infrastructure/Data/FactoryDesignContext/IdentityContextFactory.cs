using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartAPI.Infrastructure.Data.FactoryDesignContext {
    internal class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityDbContext> {
        public IdentityDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            var conectionString = "Host=localhost;Port=5432;Database=SmartAPI;Username=Davi;Password=123";

            optionsBuilder.UseNpgsql(conectionString);

            return new IdentityDbContext(optionsBuilder.Options);
        }
    }
}
