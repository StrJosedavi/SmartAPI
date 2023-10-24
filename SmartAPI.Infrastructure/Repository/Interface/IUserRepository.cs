using SmartAPI.Infrastructure.Data.Entity;

namespace SmartAPI.Infrastructure.Repository.Interface {
    public interface IUserRepository
    {
        public Task<dynamic> Save(User user, string password);
        public User? GetUserById(string Id);
        public User UpdateUser(User user);
    }
}
