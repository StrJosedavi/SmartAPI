using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.DTO.Result;
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

        public async Task<TokenResult> GenerateJwtToken(User user) 
        {
            //Configurações do Token
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var keyEncrypted = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["TokenExpiration"]));

            var roles = await _userManager.GetRolesAsync(user);

            //Criação do token
            var tokenDescriptor = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id), 
                    new Claim(ClaimTypes.Name, user.UserName), 
                }),
                Expires = expires,
                SigningCredentials = keyEncrypted
            };

            foreach (var role in roles) {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            //Leitura do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResult {
                tokenCode = jwt,
                expirationDate = expires.ToString()
            };
        }

        public async Task<dynamic> Login(UserLoginDTO UserLoginRequest) 
        {

            try {

                User user = await _userManager.FindByNameAsync(UserLoginRequest.UserName);

                if (user == null) {
                    throw new HttpRequestException(UserMessage.AUTH02, null, HttpStatusCode.BadRequest);
                }

                //Tenta realizar o login se sucesso gera o token de autorização
                var signInResult = await _signInManager.PasswordSignInAsync(user, UserLoginRequest.Password, false, false);

                if (!signInResult.Succeeded) {
                    throw new HttpRequestException(UserMessage.AUTH01, null, HttpStatusCode.Unauthorized);
                }

                TokenResult token = await GenerateJwtToken(user);

                return new LoginResult { Token = token, User = user };
            }
            catch (HttpRequestException ex) {
                throw ex;
            }

        }
    }
}
