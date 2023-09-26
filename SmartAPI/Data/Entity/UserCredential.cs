using API.Data.Entity.Enums;
using System.Data;

namespace SmartAPI.Data.Entity {
    public class UserCredential : BaseEntity {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public User? User { get; set; }

        public UserCredential Initialize(string login, string password, User user) 
        {
            Login = login;
            Password = password;
            User = user;

            return this;
        }
    }
}
