using API.Data.Entity.Enums;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Repository.Interface;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using SmartAPI.Services.Validations;
using SmartAPI.Util;
using System.Net;

namespace SmartAPI.Services {
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(UserRegisterRequest userRegisterRequest)
        {
            try 
            {
                User newUser = new User();
                UserCredential credential = new UserCredential();

                UserValidation.ValidateRequest(userRegisterRequest);

                string PassEncrypt = Encrypt.GenerateHash(userRegisterRequest.Password);

                newUser.Initialize(UserStatus.Active, "User");
                credential.Initialize(userRegisterRequest.Login, PassEncrypt, newUser);

                newUser = _userRepository.Save(newUser, credential);

                return newUser;
            }
            catch(Exception ex) 
            {
                throw ex;
            }   
        }

        public User GetUser(long userId) 
        {
            try 
            {

                User? user = _userRepository.GetUserById(userId);

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
