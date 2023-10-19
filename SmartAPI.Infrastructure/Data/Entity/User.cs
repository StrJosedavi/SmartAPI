using Microsoft.AspNetCore.Identity;
using SmartAPI.Infrastructure.Data.Enum;
using System.Text.Json.Serialization;

namespace SmartAPI.Infrastructure.Data.Entity {
    public class User : IdentityUser {
        public UserStatus Status { get; set; }
        [JsonIgnore]
        public UserCredential? UserCredential { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public User Initialize(string userName, string email) {
            
            UserName = userName;
            Email = email;
            CreationDate = DateTime.Now.ToUniversalTime();
            UpdateDate = DateTime.Now.ToUniversalTime();

            return this;
        }
    }
}
