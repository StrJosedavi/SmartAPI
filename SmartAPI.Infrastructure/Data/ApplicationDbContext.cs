using Microsoft.EntityFrameworkCore;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
