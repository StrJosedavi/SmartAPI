using SmartAPI.Data;
using SmartAPI.Services.Interface;

namespace SmartAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
