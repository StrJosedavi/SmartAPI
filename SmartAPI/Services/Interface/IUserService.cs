using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;

namespace SmartAPI.Services.Interface
{
    public interface IUserService
    {
        public User Register(UserRegisterRequest userRegisterRequest);
        public User GetUser(long UserId);
    }
}
