using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Repository.Interface;
using SmartAPI.Services.Exceptions;
using SmartAPI.Services.Interface;
using StatusCode = System.Net.HttpStatusCode;


namespace SmartAPI.Services {
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
            try 
            {
                if (userId <= 0) {
                    throw new UserException(StatusCode.BadRequest);
                }

                User? user = _userRepository.GetUserById(userId);

                if (user == null) {
                    throw new UserException(StatusCode.NotFound);
                }

                return user;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
