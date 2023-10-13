using SmartAPI.Infrastructure.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartAPI.Infrastructure.Data.Entity {
    public class User : BaseEntity {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        public Role Role { get; set; }

        [ForeignKey("UserCredentialId")]
        [JsonIgnore]
        public UserCredential? UserCredential { get; set; }

        public User Initialize(UserStatus status, Role role) {
            Status = status;
            Role = role;
            CreationDate = DateTime.Now.ToUniversalTime();
            UpdateDate = DateTime.Now.ToUniversalTime();

            return this;
        }
    }
}
