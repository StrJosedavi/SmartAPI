using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SmartAPI.Auth {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase {

        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration) {
            _configuration = configuration;
        }


        /// <summary>
        /// Geração de token de autenticação
        /// </summary>
        /// <returns>Sucesso na geração de token</returns>
        [AllowAnonymous]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GenerateToken() {
            var token = GenerateJwtToken();
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken() {

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
