using API.Data.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartAPI.Data.Entity;
using SmartAPI.Data.Enum;

namespace SmartAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            var enumToStringUserStatus = new EnumToStringConverter<UserStatus>();
            var enumToStringRole = new EnumToStringConverter<Role>();

            modelBuilder
                .Entity<User>()
                .Property(e => e.Status)
                .HasConversion(enumToStringUserStatus);

            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(enumToStringRole);

            base.OnModelCreating(modelBuilder);

        }
    }
}
