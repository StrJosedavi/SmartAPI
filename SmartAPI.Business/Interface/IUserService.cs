using SmartAPI.Business.Result;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Business.Interface {
    public interface IUserService
    {
        public UserRegisterResult Register(UserRegisterDTO userRegisterRequest);
        public User GetUser(GetUserByIdDTO getUserByIdRequest);
    }
}
