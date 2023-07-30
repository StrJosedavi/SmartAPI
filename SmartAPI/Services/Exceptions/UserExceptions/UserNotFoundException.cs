namespace SmartAPI.Services.Exceptions.UserExceptions
{
    public class UserNotFoundException : UserException
    {
        public UserNotFoundException() : base("Usuário não encontrado.")
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
