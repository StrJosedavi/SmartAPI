using SmartAPI.Infrastructure.Data;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Infrastructure.Repository {
    public class UserRepository : IUserRepository {

        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public User Save(User user) 
        {
            try {
                using (_dbContext.Database.BeginTransaction()) {
                    _dbContext.User.Add(user);
                    _dbContext.SaveChanges();

                    _dbContext.Database.CommitTransaction();
                };
                return user;
            }
            catch (Exception ex) {
                _dbContext.Database.RollbackTransaction();
                throw ex;
            }
        }

        public User UpdateUser(User user) {
            try {

                _dbContext.User.Update(user);
                _dbContext.SaveChanges();

                return user;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public UserCredential SaveCredential(UserCredential credential) {
            try {

                _dbContext.UserCredential.Add(credential);
                _dbContext.SaveChanges();

                return credential;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public User? GetUserById(long Id) 
        {
            try 
            {
                return _dbContext.User.Find(Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
