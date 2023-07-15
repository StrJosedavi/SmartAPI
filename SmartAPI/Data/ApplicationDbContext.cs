using Microsoft.EntityFrameworkCore;
using SmartAPI.Data.Entity;

namespace SmartAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
