using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Infrastructure.Data {
    public class ApplicationIdentityDbContext : IdentityDbContext<User, IdentityRole, string> {
        public DbSet<User> User { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .Property(p => p.Id)
                .HasColumnName("UserId");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaim");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogin");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserToken");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaim");

        }
    }
}
