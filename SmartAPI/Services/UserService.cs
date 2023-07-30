using SmartAPI.Data;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Repository;
using SmartAPI.Repository.Interface;
using SmartAPI.Services.Exceptions.UserExceptions;
using SmartAPI.Services.Interface;

namespace SmartAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(UserRegisterRequest userRegisterRequest)
        {
            
            //_userRepository.Save();
        }

        public User GetUser(long userId)
        {
            if (userId <= 0)
            {
                throw new UserInvalidException();
            }

            User? user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }
    }
}
