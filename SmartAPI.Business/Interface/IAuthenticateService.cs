using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.DTO.Result;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface
{
    public interface IAuthenticateService
    {
        public Task<dynamic> Login(UserLoginDTO UserLoginRequest);
        public Task<TokenResult> GenerateJwtToken(User user);
    }
}
