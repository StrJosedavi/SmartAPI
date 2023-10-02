using SmartAPI.Application.Models.Request;
using RequestMapperUserRegister = SmartAPI.Business.Services.DTO;

namespace SmartAPI.Application.Mapper {
    public class UserMapper {

        public RequestMapperUserRegister.UserRegisterRequest UserRequestRegisterMapper(UserRegisterRequest userRegisterRequest) {

            return new RequestMapperUserRegister.UserRegisterRequest() {
                Username = userRegisterRequest.UserName,
                Password = userRegisterRequest.Password,
                ConfirmPassword = userRegisterRequest.ConfirmPassword,
                Email = userRegisterRequest.Email,
            };
        }
    }
}
