namespace SmartAPI.Services.Exceptions.UserExceptions
{
    public class UserException : Exception
    {
        public UserException() : base("Erro Interno.")
        {
        }

        public UserException(string message) : base(message)
        {
        }

        public UserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
