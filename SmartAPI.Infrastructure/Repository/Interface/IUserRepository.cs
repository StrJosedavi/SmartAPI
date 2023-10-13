using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Infrastructure.Repository.Interface {
    public interface IUserRepository
    {
        public User Save(User user);
        public User? GetUserById(long Id);
        public UserCredential SaveCredential(UserCredential credential);
        public User UpdateUser(User user);
    }
}
