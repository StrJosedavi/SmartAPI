using SmartAPI.Business.Services.DTO;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface
{
    public interface IAuthenticateService
    {
        public Task<dynamic> Login(UserLoginDTO UserLoginRequest);
        public dynamic GenerateJwtToken(User user);
    }
}
