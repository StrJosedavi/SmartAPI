using SmartAPI.Application.Mapper;
using SmartAPI.Business.Interface;
using SmartAPI.Business.Services;
using SmartAPI.Infrastructure.Repository;
using SmartAPI.Infrastructure.Repository.Interface;

namespace SmartAPI.Application.Ioc {
    public class DependencyInjectionExtensions {
        public static IServiceCollection ConfigureServiceDependencies(IServiceCollection services) {
            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //Auth
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            //Mapper
            services.AddTransient<UserMapper>();

            return services;
        }

    }
}
