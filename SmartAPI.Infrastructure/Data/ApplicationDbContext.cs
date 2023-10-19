using Microsoft.EntityFrameworkCore;

namespace SmartAPI.Infrastructure.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}