using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAPI.Business.Interface;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Data.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SmartAPI.Business.Services
{
    public class AuthenticateService : IAuthenticateService {

        private readonly IConfiguration _configuration;

        public AuthenticateService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public dynamic GenerateJwtToken(User user) {

            //Configurações do Token
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var keyEncrypted = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["TokenExpiration"]));

            //Criação do token
            var tokenDescriptor = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Role", user.Role.ToString())
                }),

                Expires = expires,
                SigningCredentials = keyEncrypted
            };

            //Leitura do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //Construção do retorno
            var result = new {
                token = jwt,
                expirationDate = expires.ToString()
            };

            return result;
        }
    }
}
