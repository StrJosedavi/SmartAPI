using SmartAPI.Business.Services.DTO;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface {
    public interface IUserService
    {
        public User Register(UserRegisterRequest userRegisterRequest);
        public User GetUser(long UserId);
    }
}
