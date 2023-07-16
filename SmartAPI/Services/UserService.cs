using SmartAPI.Data;
using SmartAPI.Models.Request;
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

        public void Register(UserRegisterRequest userRegisterRequest)
        {
            //Excluir após a criação da lógica do serviço
            var teste = userRegisterRequest;
        }
    }
}
