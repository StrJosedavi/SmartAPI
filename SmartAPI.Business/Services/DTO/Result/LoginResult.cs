using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Services.DTO.Result {
    public class LoginResult {

        public User User { get; set; }
        public TokenResult Token { get; set; }
    }
}
