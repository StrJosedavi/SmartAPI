using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Data.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SmartAPI.Business.Services
{
    public class AuthenticateService : IAuthenticateService {

        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticateService(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager) {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
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
                    new Claim("Role", "User")
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
        public async Task<dynamic> Login(UserLoginDTO UserLoginRequest) {

            try {

                User user = await _userManager.FindByNameAsync(UserLoginRequest.UserName);

                if (user == null || !await _userManager.CheckPasswordAsync(user, UserLoginRequest.Password)) {
                    throw new HttpRequestException(UserMessage.AUTH01, null, HttpStatusCode.Unauthorized);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user, UserLoginRequest.Password, false, false);

                if (!signInResult.Succeeded) {
                    throw new HttpRequestException(UserMessage.AUTH02, null, HttpStatusCode.Unauthorized);
                }

                var token = GenerateJwtToken(user);

                var ResultLogin = new {
                    user,
                    token
                };
                
                    
                return ResultLogin;
            }
            catch (HttpRequestException ex) {
                throw ex;
            }

        }
    }
}
