using SmartAPI.Data.Entity;

namespace SmartAPI.Repository.Interface
{
    public interface IUserRepository
    {
        public void Save(User user);
        public User? GetUserById(long Id);
    }
}
