﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAPI.Business.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace SmartAPI.Business.Services
{
    public class AuthenticateService : IAuthenticateService {

        private readonly IConfiguration _configuration;

        public AuthenticateService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public dynamic GenerateJwtToken() 
        {

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var timeExpirationToken = jwtSettings["TokenExpiration"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var keyEncrypted = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(timeExpirationToken));

            var token = new JwtSecurityToken(
                expires: expires,
                signingCredentials: keyEncrypted
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = jwt, expirationDate = expires.ToString() };
        }
    }
}
