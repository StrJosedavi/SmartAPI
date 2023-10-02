using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Infrastructure.Repository.Interface {
    public interface IUserRepository
    {
        public void Save(User user);
        public User? GetUserById(long Id);
    }
}
