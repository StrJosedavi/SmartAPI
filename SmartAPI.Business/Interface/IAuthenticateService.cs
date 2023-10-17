using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface
{
    public interface IAuthenticateService
    {
        public dynamic GenerateJwtToken(User user);
    }
}
