using Microsoft.AspNetCore.Identity;
using SmartAPI.Infrastructure.Data;
using SmartAPI.Infrastructure.Data.Entity;
using SmartAPI.Infrastructure.Data.Transactions;
using SmartAPI.Infrastructure.Repository.Interface;
using System.Net;

namespace SmartAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository {

        private readonly ApplicationIdentityDbContext _IdentityContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationDbContext dbContext, ApplicationIdentityDbContext identityContext, UserManager<User> userManager) {
            _userManager = userManager;
            _IdentityContext = identityContext;
        }

        public async Task<User?> Save(User user, string password) {
            TransactionManager transaction = new TransactionManager(_IdentityContext);

            transaction.BeginTransaction();

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) {

                transaction.Rollback();
                return null;
            }
            else {

                result = await _userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded) {

                    transaction.Rollback();
                    return null;
                }
            }

            transaction.Commit();

            return user;
        }

        public User UpdateUser(User user) {

            _IdentityContext.User.Update(user);
            _IdentityContext.SaveChanges();

            return user;
        }

        public User? GetUserById(string Id) {
            return _IdentityContext.User.Find(Id);
        }
    }
}
