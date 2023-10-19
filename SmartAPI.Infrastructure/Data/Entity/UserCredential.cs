using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Infrastructure.Data.Entity
{
    public class UserCredential {
        [Key]
        public long UserCredentialId { get; set; }
        public string? Password { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public UserCredential Initialize(string password, User user) {
            Password = password;
            User = user;
            CreationDate = DateTime.Now.ToUniversalTime();
            UpdateDate = DateTime.Now.ToUniversalTime();

            return this;
        }
    }
}
