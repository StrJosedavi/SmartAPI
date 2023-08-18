using SmartAPI.Services.Interface;
using SmartAPI.Services;
using SmartAPI.Repository.Interface;
using SmartAPI.Repository;
using SmartAPI.Auth.Service;

namespace SmartAPI.Ioc {
    public class DependencyInjectionExtensions {
        public static IServiceCollection ConfigureServiceDependencies(IServiceCollection services) {
            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //Auth
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            return services;
        }

    }
}
