using Microsoft.AspNet.Identity.EntityFramework;
using SmartAPI.Infrastructure.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartAPI.Infrastructure.Data.Entity {
    public class User : IdentityUser {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        public Role Role { get; set; }
        public BaseEntity Base { get; set; }

        [JsonIgnore]
        public UserCredential? UserCredential { get; set; }

        public User Initialize(UserStatus status, Role role, string userName) {
            UserName = userName;
            Status = status;
            Role = role;
            Base.CreationDate = DateTime.Now.ToUniversalTime();
            Base.UpdateDate = DateTime.Now.ToUniversalTime();

            return this;
        }
    }
}
