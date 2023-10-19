using Microsoft.AspNetCore.Identity;
using SmartAPI.Business.Interface;
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
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<User> Register(UserRegisterDTO userRegisterDTO)
        {

            try {
                User newUser = new User();
                UserCredential credential = new UserCredential();

                string PassEncrypt = Encrypt.GenerateHash(userRegisterDTO.Password);

                newUser.Initialize(userRegisterDTO.Username, userRegisterDTO.Email);
                credential.Initialize(PassEncrypt, newUser);

                newUser.UserCredential = credential;

                var result = await _userManager.CreateAsync(newUser, PassEncrypt);

                if (!result.Succeeded) {
                    throw new HttpRequestException(UserMessage.ERROR_CREATE, null, HttpStatusCode.BadRequest);
                }

                return newUser;
                
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
