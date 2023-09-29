using SmartAPI.Models.Request;

namespace SmartAPI.Services.Validations {
    public class UserValidation {
        public static void ValidateRequest(UserRegisterRequest userRegisterRequest) 
        {

            if (string.IsNullOrEmpty(userRegisterRequest.Login) || userRegisterRequest.Login.Length > 50)
                throw new Exception();

            if (userRegisterRequest.Password != userRegisterRequest.ConfirmPassword)
                throw new Exception();

            if (userRegisterRequest.Password.Length > 64 || userRegisterRequest.Password.Length < 8)
                throw new Exception();

            if (string.IsNullOrEmpty(userRegisterRequest.Email) || !userRegisterRequest.Email.Contains("@"))
                throw new Exception();
        }


    }
}
