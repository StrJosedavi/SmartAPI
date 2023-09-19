using Microsoft.Data.SqlClient;
using SmartAPI.Data.Entity;
using SmartAPI.Middleware.ExceptionObjects;
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
            try {

                //_userRepository.Save();

            }
            catch (HandleExceptionGeneric ex) {
                throw ex;
            }
            catch(SqlException ex) {
                throw ex;
            }
        }

        public User GetUser(long userId) 
        {
            try 
            {

                User? user = _userRepository.GetUserById(userId);

                if (user == null) {
                    throw new HandleExceptionGeneric(UserMessage.NotFound, HttpStatusCode.NotFound);
                }

                return user;
            }
            catch (HandleExceptionGeneric ex)
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
