using Microsoft.AspNetCore.Identity;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Business.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, UserManager<User> userManager) {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<User> Register(UserRegisterDTO userRegisterDTO) {
            try {
                User? newUser = new();
                UserCredential credential = new();

                newUser.Initialize(userRegisterDTO.Username, userRegisterDTO.Email);

                string PassEncrypt = _userManager.PasswordHasher.HashPassword(newUser, userRegisterDTO.Password);

                newUser.UserCredential = credential.Initialize(PassEncrypt, newUser);

                newUser = await _userRepository.Save(newUser, userRegisterDTO.Password);

                if (newUser == null) 
                    throw new HttpRequestException(UserMessage.AUTH02, null, HttpStatusCode.BadRequest);
                
                return newUser;
            }
            catch {
                throw;
            }
        }

        public User GetUser(GetUserByIdDTO getUserByIdDTO) {
            try {

                User? user = _userRepository.GetUserById(getUserByIdDTO.UserId);

                if (user == null) {
                    throw new HttpRequestException(UserMessage.NOTFOUND, null, HttpStatusCode.NotFound);
                }

                return user;
            }
            catch {
                throw;
            }
        }
    }
}
