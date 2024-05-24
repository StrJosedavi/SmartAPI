using SmartAPI.Business.Interface;
using SmartAPI.Business.Result;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Business.Util;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Data.Enum;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Business.Services {
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRegisterResult Register(UserRegisterDTO userRegisterDTO)
        {

            try {
                User newUser = new User();
                UserCredential credential = new UserCredential();

                string PassEncrypt = Encrypt.GenerateHash(userRegisterDTO.Password!);

                newUser.Initialize(UserStatus.Active, Role.User, userRegisterDTO.Username!);
                credential.Initialize(userRegisterDTO.Username!, PassEncrypt, newUser);

                newUser.UserCredential = credential;
                newUser = _userRepository.Save(newUser);

                return new UserRegisterResult() { UserId = newUser.UserId, UserName = newUser.UserName, Status = Convert.ToInt32(newUser.Status)};
            }
            catch (HttpRequestException ex) {
                throw ex;
            }
        }

        public User GetUser(GetUserByIdDTO getUserByIdDTO) 
        {
            try 
            {

                User? user = _userRepository.GetUserById(getUserByIdDTO.UserId);

                if (user == null) {
                    throw new HttpRequestException(UserMessage.NOTFOUND, null, HttpStatusCode.NotFound);
                }

                return user;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
    }
}
