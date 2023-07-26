using API.Domain.Entity.Enums;
using SmartAPI.Data;
using SmartAPI.Data.Entity;

namespace SmartAPI.Repository {
    public class UserRepository {

        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Save(){
            //Mocado por enquanto
            User user = new User() {
                Status = UserStatus.Active
            };
            //Fim


            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
        }
    }
}
