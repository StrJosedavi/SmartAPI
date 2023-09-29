using API.Data.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartAPI.Data.Entity;

namespace SmartAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            var enumToStringConverter = new EnumToStringConverter<UserStatus>();

            modelBuilder
                .Entity<User>()
                .Property(e => e.Status)
                .HasConversion(enumToStringConverter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
