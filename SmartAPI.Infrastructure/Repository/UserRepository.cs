using SmartAPI.Infrastructure.Data;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Infrastructure.Repository {
    public class UserRepository : IUserRepository {

        private readonly ApplicationDbContext _dbContext;
        private readonly IdentityDbContext _IdentityContext;
        public UserRepository(ApplicationDbContext dbContext, IdentityDbContext identityContext) 
        {
            _dbContext = dbContext;
            _IdentityContext = identityContext;
        }

        public User Save(User user) 
        {
            using (var transaction = _IdentityContext.Database.BeginTransaction()) {
                try {

                    _IdentityContext.User.Add(user);
                    _IdentityContext.SaveChanges();

                    transaction.Commit();

                    return user;
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public User UpdateUser(User user) {
            try {

                _IdentityContext.User.Update(user);
                _IdentityContext.SaveChanges();

                return user;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public UserCredential SaveCredential(UserCredential credential) {
            try {

                _IdentityContext.UserCredential.Add(credential);
                _IdentityContext.SaveChanges();

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
                return _IdentityContext.User.Find(Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
