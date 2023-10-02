using SmartAPI.Infrastructure.Data.Enum;

namespace SmartAPI.Infrastructure.Data.Entity {
    public class User : BaseEntity
    {
        public UserStatus Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}
