using SmartAPI.Models.Request;

namespace SmartAPI.Services.Interface
{
    public interface IUserService
    {
        public void Register(UserRegisterRequest userRegisterRequest);
    }
}
