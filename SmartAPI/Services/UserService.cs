using Microsoft.Data.SqlClient;
using SmartAPI.Data.Entity;
using SmartAPI.Models.Request;
using SmartAPI.Repository.Interface;
using SmartAPI.Services.Interface;
using SmartAPI.Services.Messages;
using System.Net;

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
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
