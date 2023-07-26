using SmartAPI.Data;
using SmartAPI.Models.Request;
using SmartAPI.Repository;
using SmartAPI.Services.Interface;

namespace SmartAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(UserRegisterRequest userRegisterRequest)
        {
            _userRepository.Save();
        }
    }
}
