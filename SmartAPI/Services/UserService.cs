using API.Data.Entity.Enums;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Repository.Interface;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using SmartAPI.Util;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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
            try 
            {
                User newUser = new User();
                UserCredential credential = new UserCredential();

                if (userRegisterRequest.Password != userRegisterRequest.ConfirmPassword)
                    throw new Exception();

                newUser.Initialize(UserStatus.Active, "User");
                newUser = _userRepository.Save(newUser);
             
                string PassEncrypt = Encrypt.GenerateHash(userRegisterRequest.Password);
              
                credential.Initialize(userRegisterRequest.Login, PassEncrypt, newUser);
                credential = _userRepository.SaveCredential(credential);

                newUser.UserCredential = credential;
                _userRepository.UpdateUser(newUser);
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
