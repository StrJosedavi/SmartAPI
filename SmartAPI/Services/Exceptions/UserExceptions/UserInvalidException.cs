namespace SmartAPI.Services.Exceptions.UserExceptions
{
    public class UserInvalidException : UserException
    {
        public UserInvalidException() : base("Usuário Inválido.")
        {
        }

        public UserInvalidException(string message) : base(message)
        {
        }

        public UserInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
