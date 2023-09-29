using SmartAPI.Data.Entity;

namespace SmartAPI.Repository.Interface
{
    public interface IUserRepository
    {
        public User Save(User user, UserCredential userCredential);
        public User? GetUserById(long Id);
        public UserCredential SaveCredential(UserCredential credential);
        public User UpdateUser(User user);
    }
}
