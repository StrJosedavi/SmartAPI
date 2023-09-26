using API.Data.Entity.Enums;

namespace SmartAPI.Data.Entity {
    public class User : BaseEntity {
        public UserStatus Status { get; set; }
        public string? Role { get; set; }
        public UserCredential? Credential { get; set; }


        public User Initialize(UserStatus status, string role) 
        {
            Status = status;
            Role = role;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;

            return this; 
        }
    }
}
