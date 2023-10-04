using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Business.Services.Validations;
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

        public User Register(UserRegisterDTO userRegisterDTO)
        {

            try {
                User newUser = new User();
                UserCredential credential = new UserCredential();

                UserValidation.ValidateUserRegisterDTO(userRegisterDTO);

                string PassEncrypt = Encrypt.GenerateHash(userRegisterDTO.Password);

                newUser.Initialize(UserStatus.Active, Role.User);
                credential.Initialize(userRegisterDTO.Username, PassEncrypt, newUser);

                newUser = _userRepository.Save(newUser, credential);

                return newUser;
            }
            catch (Exception ex) {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
