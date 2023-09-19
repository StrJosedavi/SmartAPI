using SmartAPI.Repository;
using SmartAPI.Repository.Interface;
using SmartAPI.Security.Service;
using SmartAPI.Services;
using SmartAPI.Services.Interface;

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
