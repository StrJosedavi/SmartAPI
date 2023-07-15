using API.Domain.Entity.Enums;

namespace SmartAPI.Data.Entity
{
    public class User : BaseEntity
    {
        public UserStatus Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}
