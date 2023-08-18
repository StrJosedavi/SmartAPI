using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SmartAPI.Auth.Service {
    public class AuthenticateService : IAuthenticateService {

        private readonly IConfiguration _configuration;

        public AuthenticateService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GenerateJwtToken() {

            var jwtSettings = _configuration.GetSection("JwtSettings");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var keyEncrypted = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["TokenExpiration"]));

            var token = new JwtSecurityToken(
                jwtSettings["Issuer"],
                jwtSettings["Audience"],
                expires: expires,
                signingCredentials: keyEncrypted
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
