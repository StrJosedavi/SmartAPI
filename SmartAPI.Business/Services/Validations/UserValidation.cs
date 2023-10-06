using SmartAPI.Business.Services.DTO;
using SmartAPI.Business.Services.Messages;
using System.Net;

namespace SmartAPI.Business.Services.Validations {
    public class UserValidation {
        public static void ValidateUserRegisterDTO(UserRegisterDTO userRegisterRequest) 
        {

            if (userRegisterRequest.Username.Length > 50)
                throw new HttpRequestException(UserMessage.VALIDATIONREQUEST01, null, HttpStatusCode.BadRequest);

            if (userRegisterRequest.Password != userRegisterRequest.ConfirmPassword)
                throw new HttpRequestException(UserMessage.VALIDATIONREQUEST02, null, HttpStatusCode.BadRequest);

            if (userRegisterRequest.Password.Length > 64 || userRegisterRequest.Password.Length < 8)
                throw new HttpRequestException(UserMessage.VALIDATIONREQUEST03, null, HttpStatusCode.BadRequest);

            if (string.IsNullOrEmpty(userRegisterRequest.Email) || !userRegisterRequest.Email.Contains("@"))
                throw new HttpRequestException(UserMessage.VALIDATIONREQUEST04, null, HttpStatusCode.BadRequest);
        }


    }
}
