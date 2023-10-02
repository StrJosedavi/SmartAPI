using SmartAPI.Application.Models.Request;
using RequestMapperUserRegister = SmartAPI.Business.Services.DTO;

namespace SmartAPI.Application.Mapper {
    public class UserMapper {

        public RequestMapperUserRegister.UserRegisterRequest UserRequestRegisterMapper(UserRegisterRequest userRegisterRequest) {

            return new RequestMapperUserRegister.UserRegisterRequest() {
                UserName = userRegisterRequest.UserName,
                Email = userRegisterRequest.Email,
                Password = userRegisterRequest.Password
            };
        }
    }
}
