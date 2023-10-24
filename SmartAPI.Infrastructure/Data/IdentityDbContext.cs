using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Data.Enum;

namespace SmartAPI.Infrastructure.Data {
    public class IdentityDbContext : IdentityDbContext<User> {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            var enumToStringUserStatus = new EnumToStringConverter<UserStatus>();

            modelBuilder
                .Entity<User>()
                .Property(e => e.Status)
                .HasConversion(enumToStringUserStatus);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .Property(p => p.Id)
                .HasColumnName("UserId");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

        }
    }
}
