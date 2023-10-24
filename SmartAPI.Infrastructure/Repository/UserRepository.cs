using Microsoft.AspNetCore.Identity;
using SmartAPI.Infrastructure.Data;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Infrastructure.Repository {
    public class UserRepository : IUserRepository {

        private readonly ApplicationDbContext _dbContext;
        private readonly IdentityDbContext _IdentityContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationDbContext dbContext, IdentityDbContext identityContext, UserManager<User> userManager) 
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _IdentityContext = identityContext;
        }

        public async Task<dynamic> Save(User user, string password) 
        {
            using (var transaction = _IdentityContext.Database.BeginTransaction()) 
            {
                try {
                    var result = await _userManager.CreateAsync(user, password);

                    if (!result.Succeeded) {
                      
                        transaction.Rollback();
                        return result;
                    }
                    else {
                       
                        result = await _userManager.AddToRoleAsync(user, "User");

                        if (!result.Succeeded) {
                            
                            transaction.Rollback();
                            return result;
                        }
                    }

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

        public User? GetUserById(string Id) 
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
