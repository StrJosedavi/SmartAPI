using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
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
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["TokenExpiration"]));

            //Buscar roles do usuário
            var roles = await _userManager.GetRolesAsync(user);

            //Definindo Claims
            List<Claim> ClaimsList = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            ClaimsList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var claimsIdentity = new ClaimsIdentity(ClaimsList);

            //Criação do token (Payload)
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = claimsIdentity,
                Expires = expires,
                SigningCredentials = credentials
            };
            
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
