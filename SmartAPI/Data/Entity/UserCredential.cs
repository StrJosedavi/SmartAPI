using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartAPI.Data.Entity {
    public class UserCredential : BaseEntity 
    {
        [Key]
        public long UserCredentialId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public UserCredential Initialize(string login, string password, User user) 
        {
            Login = login;
            Password = password;
            User = user;
            CreationDate = DateTime.Now.ToUniversalTime();
            UpdateDate = DateTime.Now.ToUniversalTime();

            return this;
        }
    }
}
